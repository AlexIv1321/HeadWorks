using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HeadWorksDragonFight.Configuration;
using HeadWorksDragonFight.DAL;
using HeadWorksDragonFight.Core.Interfaces;
using HeadWorksDragonFight.DAL.Repositories;
using HeadWorksDragonFight.BLL.Services;
using HeadWorksDragonFight.DAL.MappingProfiles;
using FluentValidation.AspNetCore;
using HeadWorksDragonFight.Validation;
using HeadWorksDragonFight.DAL.Validation;

namespace HeadWorksDragonFight
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }
        private const string AUTHORIZATION_SETTING_NAME = "AuthorizationSettingName";
        private const string DEFAULT_CONNECTION_STRING = "DefaultConnectionString";

        public void ConfigureServices(IServiceCollection services)
        {
            var authorizationSettingName = new AuthorizationSettings();
            _configuration.Bind(AUTHORIZATION_SETTING_NAME, authorizationSettingName);
            services.AddSingleton(authorizationSettingName);

            string connectionString = _configuration.GetConnectionString(DEFAULT_CONNECTION_STRING);
            services.AddTransient<HeadWorksDragonFightContext>();
            services.AddDbContext<HeadWorksDragonFightContext>(opt =>
              opt.UseSqlServer(connectionString));
            services.AddControllers();

            ConnectionServiceSetting(services);
            AuthenticationSetting(services, authorizationSettingName);
            MapperConfigurationSetting(services);
            FluentValidationSetting(services);
            services.AddMvc();

            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
           
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
           
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

              app.UseEndpoints(endpoints =>
              {
                  endpoints.MapDefaultControllerRoute();
              });

        }
        public void ConnectionServiceSetting(IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountsRepository), typeof(AccountsRepository));
            services.AddScoped(typeof(IPasswordHasher), typeof(PasswordHasher));
            services.AddScoped(typeof(IAccountsService), typeof(AccountService));
            services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
        }

        public void MapperConfigurationSetting(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new HeroProfile());
                mc.AddProfile(new HeadWorksDragonFight.MappingProfiles.HeroProfile());
                mc.AddProfile(new DragonProfile());
                mc.AddProfile(new HitProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void AuthenticationSetting(IServiceCollection services, AuthorizationSettings authorizationSettingName)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = authorizationSettingName.Issuer,
                            ValidateAudience = true,
                            ValidAudience = authorizationSettingName.Audience,
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authorizationSettingName.Key)),
                            ValidateIssuerSigningKey = true,
                        };
                    });
        }
        public void FluentValidationSetting(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterHeroValidator>());
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterDragonValidator>());
        }
    }
}

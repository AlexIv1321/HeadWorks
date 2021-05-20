using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HeadWorksDragonFight.DAL
{
    public class HostedServiceMigration : IHostedService
    {
        private readonly IServiceScopeFactory _serviceProvider;
        public HostedServiceMigration(IServiceScopeFactory serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var _serviceScope = _serviceProvider.CreateScope();
            var dbContext = _serviceScope.ServiceProvider.GetService<HeadWorksDragonFightContext>();

            await dbContext.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

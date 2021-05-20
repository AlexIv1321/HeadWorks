using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HeadWorksDragonFight.Models; 
using AutoMapper;
using HeadWorksDragonFight.Core.Interfaces;
using HeadWorksDragonFight.Configuration;
using System;
using HeadWorksDragonFight.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HeadWorksDragonFight.Dal.Models;
using System.Linq;

namespace HeadWorksDragonFight.Controllers
{
    public class AccountController : Controller
    { 
        private readonly IMapper _mapper;
        private readonly IAccountsService _heroService;
        private readonly AuthorizationSettings _authSettings;
        private const string ERROR_TEXT = "Invalid username or password.";
        private const string ERROR_ENTER = "Некорректные логин и(или) пароль";

        public AccountController(IMapper mapper, IAccountsService heroService, AuthorizationSettings authSettings)
        {
            _mapper = mapper;
            _heroService = heroService;
            _authSettings = authSettings;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token(RegisterHero registerHero)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ERROR_ENTER);
                return View();
            }

             var identity = await _heroService.AuthorizeAsync(registerHero.Login, registerHero.Password);
             if (identity == null)
             {
                 return BadRequest(new { errorText = ERROR_TEXT });
             }

             var encodedJwt = GetIdentity(identity);

            var response = new
            {
                access_token = encodedJwt,
                username = identity
            };
           
               return Json(response);
            
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterHero registerHero)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ERROR_ENTER);
                return View();
            }

            var hero = _mapper.Map<Hero>(registerHero);
            await _heroService.CreateAsync(hero);
            return RedirectToAction("Menu", "Menu");
        }

        public string GetIdentity(string identity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, identity.ToString())
            };

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: _authSettings.Issuer,
                audience: _authSettings.Audience,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromDays(_authSettings.Lifetime)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authSettings.Key)), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
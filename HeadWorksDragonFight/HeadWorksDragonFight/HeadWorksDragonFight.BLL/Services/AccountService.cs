using HeadWorksDragonFight.Core.Interfaces;
using HeadWorksDragonFight.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.BLL.Services
{
    public class AccountService : IAccountsService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountsRepository _usersRepository;

        public AccountService(IPasswordHasher passwordHasher, IAccountsRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> AuthorizeAsync(string login, string password)
        {
            var user = await _usersRepository.GetAsync(login);

            if (user != null)
            {
                if (_passwordHasher.VerifyHashedPassword(user.Password, password))
                {
                    return user.Id.ToString();
                }
                return null;
            }
            return null;
        }

        public async Task CreateAsync(Hero hero)
        {
            hero.Password = _passwordHasher.Hash(hero.Password);
            await _usersRepository.CreateAsync(hero);
        }
    }
}

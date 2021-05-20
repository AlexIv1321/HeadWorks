using HeadWorksDragonFight.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.Core.Interfaces
{
    public interface IAccountsService
    {
        Task<string> AuthorizeAsync(string login, string password);

        Task CreateAsync(Hero hero);
    }
}

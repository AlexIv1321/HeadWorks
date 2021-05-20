using HeadWorksDragonFight.Core.Models;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.Core.Interfaces
{
    public interface IAccountsRepository
    {
        Task CreateAsync(Hero item);
        Task<Hero> GetAsync(string login);
    }
}

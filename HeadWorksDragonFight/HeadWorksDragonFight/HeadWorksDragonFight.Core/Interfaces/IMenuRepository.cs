using HeadWorksDragonFight.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.Core.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Hero>> GetHeroesAsync();
        Task<IEnumerable<Dragon>> GetDragonsAsync();
        Task CreateAsync();
        Task<Hero> GetUserAsyns(Guid? idHero);
        Task<Dragon> GetDragonAsyns(Guid? idDragon);
        Task<Dragon> HitAsyns(Hero hero, Dragon dragon);
        Task<IEnumerable<Hero>> GetHeroAsyns(string name);
        Task<IEnumerable<Dragon>> GetDragonAsyns(string name);
        Task<IEnumerable<Hit>> AllHitAsyns(Guid id);
        Task<IEnumerable<Dragon>> HpMaxDragonAsyns(int hpMax);
        Task<IEnumerable<Dragon>> HpDragonAsyns(int hp);

    }
}

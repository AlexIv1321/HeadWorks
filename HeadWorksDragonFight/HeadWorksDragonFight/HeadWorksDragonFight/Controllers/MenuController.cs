using HeadWorksDragonFight.Core.Interfaces;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Extensions;
using HeadWorksDragonFight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [Route("allheroesasync")]
        public async Task<IActionResult> AllHeroesAsync()
        {
            return View(await _menuRepository.GetHeroesAsync());
        }
        [Route("alldragonsasync")]
        public async Task<IActionResult> AllDragonsAsync()
        {
            return View(await _menuRepository.GetDragonsAsync());
        }
        [Route("createdragonasync")]
        public async Task<IActionResult> CreateDragonAsync()
        {
            await _menuRepository.CreateAsync();
            return View(await _menuRepository.GetDragonsAsync());
        }
        [Route("fightasyns")]
        public async Task<IActionResult> FightAsyns(Guid? Dragonid)
        {
            if (!Dragonid.HasValue)
            {
                return NotFound();
            }
            var result = await _menuRepository.GetDragonAsyns(Dragonid);

            return View(result);
        }
        [Route("hitasyns")]
        public async Task<IActionResult> HitAsyns(Guid? Dragonid)
        {
            if (!Dragonid.HasValue)
            {
                return NotFound();
            }
            var hero = await _menuRepository.GetUserAsyns(this.GetUserId());
            var dragon = await _menuRepository.GetDragonAsyns(Dragonid);

            var dragonHp = await _menuRepository.HitAsyns(hero, dragon);

            if (dragonHp == null)
            {
                return RedirectToAction("Menu", "AllDragons");
            }
            return View(dragonHp);
        }
        [Route("getheroasyns")]
        public async Task<IActionResult> GetHeroAsyns(string Name)
        {
            return View(await _menuRepository.GetHeroAsyns(Name));
        }
        [Route("getdragonasyns")]
        public async Task<IActionResult> GetDragonAsyns(string Name)
        {
            return View(await _menuRepository.GetDragonAsyns(Name));
        }
        [Route("orderbyhero")]
        public async Task<IActionResult> OrderByHero()
        {
            var result = await _menuRepository.GetHeroesAsync();
            return View(result.OrderBy(x => x.Date));
        }
        [Route("orderbydragon")]
        public async Task<IActionResult> OrderByDragon()
        {
            var result = await _menuRepository.GetDragonsAsync();
            return View(result.OrderBy(x => x.Date));
        }
        [Route("orderbydescendinghero")]
        public async Task<IActionResult> OrderByDescendingHero()
        {
            var result = await _menuRepository.GetHeroesAsync();
            return View(result.OrderByDescending(x => x.Date));
        }
        [Route("orderbydescendingdragon")]
        public async Task<IActionResult> OrderByDescendingDragon()
        {
            var result = await _menuRepository.GetDragonsAsync();
            return View(result.OrderByDescending(x => x.Date));
        }
        [Route("hitdragonsasyns")]
        public async Task<IActionResult> HitDragonsAsyns()
        {
            return View(await _menuRepository.AllHitAsyns(this.GetUserId()));
        }
        [Route("hitorderbynamedragonsasyns")]
        public async Task<IActionResult> HitOrderByNameDragonsAsyns()
        {
            var result = await _menuRepository.AllHitAsyns(this.GetUserId());
            return View(result.OrderBy(x => x.NameDragon));
        }
        [Route("hitorderbydescendingnamedragonsasyns")]
        public async Task<IActionResult> HitOrderByDescendingNameDragonsAsyns()
        {
            var result = await _menuRepository.AllHitAsyns(this.GetUserId());
            return View(result.OrderByDescending(x => x.NameDragon));
        }
        [Route("hitorderbyasyns")]
        public async Task<IActionResult> HitOrderByAsyns()
        {
            var result = await _menuRepository.AllHitAsyns(this.GetUserId());
            return View(result.OrderBy(x => x.ImpactForce));
        }
        [Route("hitorderbydescendingasyns")]
        public async Task<IActionResult> HitOrderByDescendingAsyns()
        {
            var result = await _menuRepository.AllHitAsyns(this.GetUserId());
            return View(result.OrderByDescending(x => x.ImpactForce));
        }
        [Route("getdragonbyidasyns")]
        public async Task<IActionResult> GetDragonByIdAsyns(Guid dragonid)
        {
            return View (await _menuRepository.GetDragonAsyns(dragonid));
        }
        [Route("hpmaxdragonasyns")]
        public async Task<IActionResult> HpMaxDragonAsyns(int hpMax)
        {
            return View(await _menuRepository.HpMaxDragonAsyns(hpMax));
        }
        [Route("hpdragonasyns")]
        public async Task<IActionResult> HpDragonAsyns(int hp)
        {
            return View(await _menuRepository.HpDragonAsyns(hp));
        }
        [Route("hpmaxorderbydragonasyns")]
        public async Task<IActionResult> HpMaxOrderByDragonAsyns()
        {
            var result = await _menuRepository.GetDragonsAsync();
            return View(result.OrderBy(x => x.HpMax));
        }
        [Route("hpmaxorderbydescendingdragonasyns")]
        public async Task<IActionResult> HpMaxOrderByDescendingDragonAsyns()
        {
            var result = await _menuRepository.GetDragonsAsync();
            return View(result.OrderByDescending(x => x.HpMax));
        }
        [Route("hporderbydragonasyns")]
        public async Task<IActionResult> HpOrderByDragonAsyns()
        {
            var result = await _menuRepository.GetDragonsAsync();
            return View(result.OrderBy(x => x.Hp));
        }
        [Route("hporderbydescendingdragonasyns")]
        public async Task<IActionResult> HpOrderByDescendingDragonAsyns()
        {
            var result = await _menuRepository.GetDragonsAsync();
            return View(result.OrderByDescending(x => x.Hp));
        }
    }
}

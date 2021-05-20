using AutoMapper;
using HeadWorksDragonFight.Core.Interfaces;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Dal.Models;
using HeadWorksDragonFight.DAL.Validation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HeadWorksDragonFight.DAL.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly HeadWorksDragonFightContext _context;
        private readonly IMapper _mapper;
        private const int SQL_EXCEPTION_DUPLICATE_KEY = 2627;
        private int _numberNameList = 0;
        private const string LIST_NAME_DRAGON = @"C:\Users\Ырырыр\source\repos\HeadWorksDragonFight\test.txt";

        public MenuRepository(HeadWorksDragonFightContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync()
        {

            var dragonDal = new DragonDal();

            List<string> AllName = GetName();

            dragonDal.Id = Guid.NewGuid();

            Random rand = new Random();
            dragonDal.Hp = rand.Next(80, 100);
            dragonDal.HpMax = dragonDal.Hp;

            dragonDal.Date = DateTime.Now;

            while (_numberNameList != -1)
            {
                if (_numberNameList < AllName.Count)
                {
                    dragonDal.Name = AllName[0 + _numberNameList];
                    await Name(dragonDal);
                }
                else
                {
                    break; // максимум драконов создан
                }
            }
        }

        public async Task<IEnumerable<Dragon>> GetDragonsAsync()
        {
            return _mapper.Map<IEnumerable<Dragon>>(await _context.Dragons.ToListAsync());
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            return _mapper.Map<IEnumerable<Hero>>(await _context.Heroes.ToListAsync());
        }

        public List<string> GetName()
        {
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(LIST_NAME_DRAGON, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }

        public async Task Name(DragonDal dragonDal)
        {
            var validator = new RegisterDragonValidator();
            var results = validator.Validate(dragonDal);
            if (!results.IsValid)
            {
                _numberNameList++;
            }
            else
            {
                try
                {
                    await _context.Dragons.AddAsync(dragonDal);
                    await _context.SaveChangesAsync();
                    _numberNameList = -1;
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException && sqlException.Number == SQL_EXCEPTION_DUPLICATE_KEY)
                {
                    _numberNameList++;
                }
            }
        }

        public async Task<Dragon> HitAsyns(Hero hero, Dragon dragon)
        {
            Random rand = new Random();
            HitDal hitDal = new HitDal();

            var heroDal = _mapper.Map<HeroDal>(hero);
            var dragonDal = _mapper.Map<DragonDal>(dragon);

            int damage = (heroDal.Weapon + rand.Next(1, 3));

            hitDal.DragonDalId = dragonDal.Id;
            hitDal.HeroDalId = heroDal.Id;
            hitDal.ImpactForce = damage;
            hitDal.StrikeTime = rand.Next(1, 5);
            hitDal.NameDragon = dragonDal.Name;

            dragonDal.Hp -= damage;

            if (dragonDal.Hp < 0)
            {
                await _context.Hits.AddAsync(hitDal);
                _context.Dragons.Update(dragonDal);
                await _context.SaveChangesAsync();

                _context.Set<DragonDal>().Remove(dragonDal);
                await _context.SaveChangesAsync();
                return null;
            }
            _context.Dragons.Update(dragonDal);
            await _context.Hits.AddAsync(hitDal);
            await _context.SaveChangesAsync();

            return _mapper.Map<Dragon>(dragonDal);

        }

        public async Task<Hero> GetUserAsyns(Guid? idHero)
        {
            return _mapper.Map<Hero>( await _context.Heroes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idHero));
        }

        public async Task<Dragon> GetDragonAsyns(Guid? idDragon)
        {
            return _mapper.Map<Dragon>(await _context.Dragons.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idDragon));
        }

        public async Task<IEnumerable<Hero>> GetHeroAsyns(string name)
        {
            if (name == null)
            {
                return null; // Имя не может быть null
            }
            var listHeroes = new List<Hero>();
          
            var nameUpperCase = name.ToUpper().ToCharArray();
            var heroes = await _context.Heroes.ToListAsync();

            foreach (var hero in heroes)
            {
                string[] words = hero.Login.Split(new char[] { ' ' });

                foreach (string s in words)
                {
                    var LoginUpperCase = s.ToUpper().ToCharArray();

                    int indexOfSubstring = LoginUpperCase.ToString().IndexOf(nameUpperCase.ToString());

                    if (indexOfSubstring != -1 && nameUpperCase[0] == LoginUpperCase[0])
                    {
                        listHeroes.Add(_mapper.Map<Hero>(hero));
                    }
                }
            }
            return listHeroes;
        }

        public async Task<IEnumerable<Dragon>> GetDragonAsyns(string name)
        {
            if (name == null)
            {
                return null; // Имя не может быть null
            }
            var listDragons = new List<Dragon>();

            var nameUpperCase = name.ToUpper().ToCharArray();
            var dragons = await _context.Dragons.ToListAsync();

            foreach (var dragon in dragons)
            {
                string[] words = dragon.Name.Split(new char[] { ' ' });

                foreach (string s in words)
                {
                    var nameDragonUpperCase = s.ToUpper().ToCharArray();

                    int indexOfSubstring = nameDragonUpperCase.ToString().IndexOf(nameUpperCase.ToString());

                    if (indexOfSubstring != -1 && nameUpperCase[0]== nameDragonUpperCase[0])
                    {
                        listDragons.Add(_mapper.Map<Dragon>(dragon));
                    }
                }
            }
            return listDragons;
        }

        public async Task<IEnumerable<Hit>> AllHitAsyns(Guid id)
        {
            var result = new List<Hit>();
            var number = 0;

            var hits = await _context.Hits.Where(x => x.HeroDalId == id).ToListAsync();
           
            var res = hits.Select(s => new { s.DragonDalId, s.NameDragon }).Distinct();

            foreach (var guid in res)
            {
                foreach (var hit in hits)
                {
                    if (hit.DragonDalId == guid.DragonDalId)
                    {
                        number += hit.ImpactForce;
                    }
                }
                result.Add(new Hit()
                {
                    Id = Guid.NewGuid(),
                    HeroId = id,
                    DragonId = guid.DragonDalId,
                    ImpactForce = number,
                    NameDragon = guid.NameDragon,
                }) ;
                number = 0;
            }
            return result;
        }

        public async Task<IEnumerable<Dragon>> HpMaxDragonAsyns(int hpMax)
        {
           return _mapper.Map<IEnumerable<Dragon>>(await _context.Dragons.Where(x => x.HpMax == hpMax).ToListAsync());
        }

        public async Task<IEnumerable<Dragon>> HpDragonAsyns(int hp)
        {
            return _mapper.Map<IEnumerable<Dragon>>(await _context.Dragons.Where(x => x.Hp == hp).ToListAsync());
        }
    }

}

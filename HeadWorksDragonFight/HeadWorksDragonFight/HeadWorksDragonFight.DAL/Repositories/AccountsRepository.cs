using AutoMapper;
using HeadWorksDragonFight.Core.Exceptions;
using HeadWorksDragonFight.Core.Interfaces;
using HeadWorksDragonFight.Core.Models;
using HeadWorksDragonFight.Dal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.DAL.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly HeadWorksDragonFightContext _context;
        private readonly IMapper _mapper;
        private const int SQL_EXCEPTION_DUPLICATE_KEY = 2627;
        private const string EXCEPTION_ALREADY_EXISTS = "Hero already exist";

        public AccountsRepository(HeadWorksDragonFightContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(Hero hero)
        {
            try
            {
                var userDal = _mapper.Map<HeroDal>(hero);
                userDal.Id = Guid.NewGuid();

                Random rand = new Random();
                userDal.Weapon = rand.Next(1, 6);

                userDal.Date = DateTime.Now;

                await _context.Heroes.AddAsync(userDal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException && sqlException.Number == SQL_EXCEPTION_DUPLICATE_KEY)
            {
                throw new EntityAlreadyExistsException(EXCEPTION_ALREADY_EXISTS);
            }
        }

        public async Task<Hero> GetAsync(string login)
        {
            var userDal = await _context.Heroes.AsNoTracking().FirstOrDefaultAsync(x => x.Login == login);
            return _mapper.Map<Hero>(userDal);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.DAL
{
    public class HeadWorksDragonFightContextFactory : IDesignTimeDbContextFactory<HeadWorksDragonFightContext>
    {
        public HeadWorksDragonFightContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HeadWorksDragonFightContext>();
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HeadWorks;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new HeadWorksDragonFightContext(optionsBuilder.Options);
        }
    }
}

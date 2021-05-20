using HeadWorksDragonFight.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeadWorksDragonFight.DAL
{
    public partial class HeadWorksDragonFightContext : DbContext
    {
        public HeadWorksDragonFightContext(DbContextOptions<HeadWorksDragonFightContext> options)
             : base(options)
        {

        }

        public DbSet<HeroDal> Heroes { get; set; }

        public DbSet<DragonDal> Dragons { get; set; }

        public DbSet<HitDal> Hits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroDal>().HasKey(u => u.Id);
            modelBuilder.Entity<HeroDal>().HasAlternateKey(u => u.Login);

            modelBuilder.Entity<DragonDal>().HasKey(u => u.Id);
            modelBuilder.Entity<DragonDal>().HasAlternateKey(u => u.Name);

            modelBuilder.Entity<HitDal>().HasKey(u => u.Id);

            modelBuilder.Entity<HitDal>().HasOne(p => p.HeroDal).WithMany(b => b.HitDal).HasForeignKey(p => p.HeroDalId).HasPrincipalKey(b => b.Id);
        }
    }
}

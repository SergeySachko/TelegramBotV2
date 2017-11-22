using Application.Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.DAL
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<HeroAttribute> HeroAttributes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureHeroEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureHeroEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasKey(br => br.Id);
            modelBuilder.Entity<Hero>()
                .HasMany(br => br.Attributes)
                .WithOne(h => h.Hero);
        }
    }
}

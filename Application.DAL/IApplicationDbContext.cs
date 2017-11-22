using Application.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DAL
{
    public  interface IApplicationDbContext : IDisposable
    {
        DbSet<Hero> Heroes { get; set; }

        DbSet<HeroAttribute> HeroAttributes { get; set; }

        int SaveChanges();
    }
}

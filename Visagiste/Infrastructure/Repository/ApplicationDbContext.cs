using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Photo> Photos { get; set; }

        internal ApplicationDbContext Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().Property(p => p.Tags).HasConversion(t => string.Join(",", t), s => s.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            modelBuilder.Entity<Owner>().Property(o => o.Banners).HasConversion(b => string.Join(",", b), s => s.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}

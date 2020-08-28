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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().Property(p => p.Tags).HasConversion(v => string.Join(",", v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}

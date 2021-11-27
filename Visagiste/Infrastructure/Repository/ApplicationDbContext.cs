using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Photo> Photos { get; set; }

        //internal ApplicationDbContext Include(Func<object, object> p)
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ValueConverter converter = new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            ValueComparer comparer = new ValueComparer<List<string>>(
                (list1, list2) => list1.SequenceEqual(list2),
                list => list.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())));

            modelBuilder
                .Entity<Photo>()
                .Property(p => p.Tags)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);


            modelBuilder
                .Entity<Owner>()
                .Property(o => o.Banners)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);
        }
    }
}

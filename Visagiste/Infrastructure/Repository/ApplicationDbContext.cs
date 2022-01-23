using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment) : base(options)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ValueConverter converter = new ValueConverter<List<string>, string>(
                l => JsonConvert.SerializeObject(l),
                s => JsonConvert.DeserializeObject<List<string>>(s));

            ValueComparer comparer = new ValueComparer<List<string>>(
                (list1, list2) => list1.SequenceEqual(list2),
                list => list.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())));

            modelBuilder
                .Entity<Owner>()
                .Property(o => o.Banners)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);

            modelBuilder.Entity<Photo>().HasData(
                new Photo() { Id = 1, Name = "image_1.jpg" },
                new Photo() { Id = 2, Name = "image_2.jpg" },
                new Photo() { Id = 3, Name = "image_3.jpg" },
                new Photo() { Id = 4, Name = "image_4.jpg" },
                new Photo() { Id = 5, Name = "image_5.jpg" },
                new Photo() { Id = 6, Name = "image_6.jpg" },
                new Photo() { Id = 7, Name = "image_7.jpg" },
                new Photo() { Id = 8, Name = "image_8.jpg" },
                new Photo() { Id = 9, Name = "image_9.jpg" },
                new Photo() { Id = 10, Name = "image_10.jpg" },
                new Photo() { Id = 11, Name = "image_11.jpg" },
                new Photo() { Id = 12, Name = "image_12.jpg" });
            
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Model" },
                new Tag { Id = 2, Name = "Visagiste" });

            modelBuilder.Entity<PhotoTagJunction>().HasData(
                new PhotoTagJunction { Id = 1, PhotoId = 1, TagId = 1 },
                new PhotoTagJunction { Id = 2, PhotoId = 2, TagId = 1 },
                new PhotoTagJunction { Id = 3, PhotoId = 3, TagId = 1 },
                new PhotoTagJunction { Id = 4, PhotoId = 4, TagId = 1 },
                new PhotoTagJunction { Id = 5, PhotoId = 5, TagId = 1 },
                new PhotoTagJunction { Id = 6, PhotoId = 6, TagId = 1 },
                new PhotoTagJunction { Id = 7, PhotoId = 7, TagId = 1 },
                new PhotoTagJunction { Id = 8, PhotoId = 8, TagId = 1 },
                new PhotoTagJunction { Id = 9, PhotoId = 9, TagId = 1 },
                new PhotoTagJunction { Id = 10, PhotoId = 1, TagId = 2 },
                new PhotoTagJunction { Id = 11, PhotoId = 2, TagId = 2 });

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 1,
                    Name = "Ivan Ivanov",
                    Banners = new List<string>(2) { "/images/SeedData/banner-1.jpg", "/images/SeedData/banner-2.jpg" },
                    AboutMe = "I am A Photographer from America Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean."
                });

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Address = "203 Fake St. Mountain View, San Francisco, California, USA",
                    Email = "info@yourdomain.com",
                    Phone = "+2 392 3929 210",
                    InstagramUrl = "https://www.instagram.com/",
                    VkUrl = "https://vk.com/",
                    Map = "<script type=\"text/javascript\" charset=\"utf-8\" async src=\"https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3A3c1d989bb05c7ef404fd41c59995fe2231f79de65bef8c8c41033e8682000645&amp;lang=ru_RU&amp;scroll=true\"></script>",
                    OwnerId = 1
                });

            modelBuilder.Entity<Avatar>().HasData(
                new Avatar
                {
                    Id = 1,
                    Image = ReadImage("author.jpg"),
                    OwnerId = 1
                });
        }

        private byte[] ReadImage(string fileName)
        {
            string fullFileName = Path.Combine(webHostEnvironment.WebRootPath, "images", "SeedData", fileName);
            if (File.Exists(fullFileName))
            {
                try
                {
                    return File.ReadAllBytes(fullFileName);
                }
                catch
                {
                    //TODO: Log
                }
            }
            return null;
        }
    }
}

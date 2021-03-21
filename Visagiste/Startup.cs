using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Visagiste.Components;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorRuntimeCompilation();

            services.AddTransient<IPhotoRepository, EFPhotoRepository>();
            services.AddTransient<IOwnerRepository, EFOwnerRepository>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext applicationDbContext)
        {
            bool createdDb = applicationDbContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                if (createdDb)
                {
                    SeedData(applicationDbContext);
                }
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void SeedData(ApplicationDbContext dbContext)
        {
            IEnumerable<Photo> photos = new List<Photo>() {
                            new Photo(){Url = "/images/image_1.jpg", Tags = new List<string>{"Model", "Visagiste" } },
                            new Photo(){Url ="/images/image_2.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_3.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_4.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_5.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_6.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_7.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_8.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_9.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_10.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_11.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){Url ="/images/image_12.jpg", Tags = new List<string>{ "Model"} }};

            dbContext.Photos.AddRange(photos);
            
            Contact contact = new Contact() { 
                Address = "203 Fake St. Mountain View, San Francisco, California, USA",
                Email = "info@yourdomain.com",
                Phone = "+2 392 3929 210",
                InstagramUrl = "https://www.instagram.com/oksanasolovey_mua/",
                VkUrl = "https://vk.com/id25029075"
            };

            Avatar avatar = new Avatar {
                Url = "/images/author.jpg",
                X = "0",
                Y = "0"
            };

            Owner owner = new Owner() { 
                Name = "Ivan Ivanov",
                Contact = contact,
                Avatar = avatar,
                Banners = new List<string> {"/images/author.jpg", "/images/author-2.jpg" },
                AboutMe = "I am A Photographer from America Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean."
            };
            dbContext.Owners.Add(owner);

            dbContext.SaveChanges();
        }
    }
}

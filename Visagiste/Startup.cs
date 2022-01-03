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
using Microsoft.AspNetCore.Identity;

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

            services.AddTransient<IPhotoRepository, EFPhotoRepository>();
            services.AddTransient<IOwnerRepository, EFOwnerRepository>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<IdentityDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext applicationDbContext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                bool ensureCreated = applicationDbContext.Database.EnsureCreated();
                if (!ensureCreated)
                {
                    SeedData(applicationDbContext);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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
                            new Photo(){FullName = "/images/image_1.jpg", Tags = new List<string>{"Model", "Visagiste" } },
                            new Photo(){FullName = "/images/image_2.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_3.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_4.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_5.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_6.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_7.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_8.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_9.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_10.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_11.jpg", Tags = new List<string>{ "Model"} },
                            new Photo(){FullName = "/images/image_12.jpg", Tags = new List<string>{ "Model"} }};

            dbContext.Photos.AddRange(photos);

            Contact contact = new Contact()
            {
                Address = "203 Fake St. Mountain View, San Francisco, California, USA",
                Email = "info@yourdomain.com",
                Phone = "+2 392 3929 210",
                InstagramUrl = "https://www.instagram.com/",
                VkUrl = "https://vk.com/"
            };

            Avatar avatar = new Avatar
            {
                Url = "/images/author.jpg"
            };

            Owner owner = new Owner()
            {
                Name = "Ivan Ivanov",
                Contact = contact,
                Avatar = avatar,
                Banners = new List<string>(2) { "/images/author.jpg", "/images/author-2.jpg" },
                AboutMe = "I am A Photographer from America Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean."
            };
            dbContext.Owners.Add(owner);

            dbContext.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            dbContext.SaveChanges();
        }
    }
}

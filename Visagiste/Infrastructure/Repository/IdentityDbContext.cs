using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;


namespace Visagiste.Infrastructure.Repository
{
    public class IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public static async Task CreateAdminAccount(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string userName = configuration["Data:AdminUser:Name"];

            IdentityUser admin = await userManager.FindByNameAsync(userName);
            if (admin == null)
            {
                string email = configuration["Data:AdminUser:Email"];
                string password = configuration["Data:AdminUser:Password"];

                admin = new IdentityUser
                {
                    UserName = userName,
                    Email = email
                };

                var result = await userManager.CreateAsync(admin, password);
            }
        }
    }
}
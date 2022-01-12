using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public class EFOwnerRepository : IOwnerRepository
    {
        private ApplicationDbContext dbContext;

        public EFOwnerRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task AddAsync(Owner owner)
        {
            await dbContext.Owners.AddAsync(owner);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Owner> GetAsync()
        {
            Owner owner = await dbContext.Owners
                .Include(o => o.Contact)
                .Include(o => o.Avatar)
                .FirstOrDefaultAsync();
            return owner;
        }

        public async Task UpdateAsync(Owner owner)
        {
            Owner dbOwner = await GetAsync();
            if (dbOwner != null)
            {
                dbOwner.Name = owner.Name;
                dbOwner.AboutMe = owner.AboutMe;
                dbOwner.Contact.Address = owner.Contact.Address;
                dbOwner.Contact.Phone = owner.Contact.Phone;
                dbOwner.Contact.Email = owner.Contact.Email;
                dbOwner.Contact.InstagramUrl = owner.Contact.InstagramUrl;
                dbOwner.Contact.VkUrl = owner.Contact.VkUrl;
                if (owner.Avatar.Image != null)
                {
                    dbOwner.Avatar.Image = owner.Avatar.Image;
                }
                dbOwner.Avatar.X = owner.Avatar.X;
                dbOwner.Avatar.Y = owner.Avatar.Y;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

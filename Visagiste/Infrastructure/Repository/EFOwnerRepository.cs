using Microsoft.EntityFrameworkCore;
using System.Linq;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Components
{
    public class EFOwnerRepository : IOwnerRepository
    {
        private ApplicationDbContext dbContext;

        public EFOwnerRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Add(Owner owner)
        {
            dbContext.Owners.Add(owner);
            dbContext.SaveChanges();
        }

        public Owner Get()
        {
            return dbContext.Owners.Include(o => o.Contact).Include(o => o.Avatar).FirstOrDefault();
        }

        public void Update(Owner owner)
        {
            Owner dbOwner = Get();
            if(dbOwner != null)
            {
                dbOwner.Name = owner.Name;
                dbOwner.AboutMe = owner.AboutMe;
                dbOwner.Contact.Address = owner.Contact.Address;
                dbOwner.Contact.Phone = owner.Contact.Phone;
                dbOwner.Contact.Email = owner.Contact.Email;
                dbOwner.Contact.InstagramUrl = owner.Contact.InstagramUrl;
                dbOwner.Contact.VkUrl = owner.Contact.VkUrl;
                dbOwner.Avatar.Url = owner.Avatar.Url;
                dbOwner.Avatar.X = owner.Avatar.X;
                dbOwner.Avatar.Y = owner.Avatar.Y;

                dbContext.SaveChanges();
            }
        }
    }
}

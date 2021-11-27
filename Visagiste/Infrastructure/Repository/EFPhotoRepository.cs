using System.Collections.Generic;
using System.Linq;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public class EFPhotoRepository : IPhotoRepository
    {
        private ApplicationDbContext dbContext;

        public EFPhotoRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<Photo> Photos => dbContext.Photos;

        public void AddPhoto(Photo photo)
        {
            dbContext.Photos.Add(photo);
            dbContext.SaveChanges();
        }

        public void DeletePhoto(Photo photo)
        {
            dbContext.Photos.Remove(photo);
            dbContext.SaveChanges();
        }

        public Photo GetPhoto(long id) => dbContext.Photos.First(p => p.Id == id);

        public void UpdatePhoto(Photo photo)
        {
            Photo photoDb = dbContext.Photos.Find(photo.Id);
            photoDb.FullName = photo.FullName;
            photoDb.Tags = photo.Tags;
            dbContext.SaveChanges();
        }
    }
}

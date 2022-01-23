using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visagiste.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Visagiste.Infrastructure.Repository
{
    public class EFPhotoRepository : IPhotoRepository
    {
        private ApplicationDbContext dbContext;

        public EFPhotoRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<Photo> Photos => dbContext.Photos
                                                     .Include(p => p.PhotoTags)
                                                     .ThenInclude(pt => pt.Tag);

        public Photo Get(int id) => dbContext.Photos.FirstOrDefault(p => p.Id == id);

        public async Task AddAsync(Photo photo)
        {
            await dbContext.Photos.AddAsync(photo);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Photo> photos)
        {
            dbContext.Photos.RemoveRange(photos);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Photo photo)
        {
            throw new NotImplementedException();
            //Photo photoDb = Get(photo.Id);
            //if (photoDb != null)
            //{
            //    photoDb.FullName = photo.FullName;
            //    photoDb.Tags = photo.Tags;
            //    await dbContext.SaveChangesAsync();
            //}
        }
    }
}
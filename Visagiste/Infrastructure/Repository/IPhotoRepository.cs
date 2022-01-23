using System.Collections.Generic;
using System.Threading.Tasks;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> Photos { get; }

        Photo Get(int id);

        Task AddAsync(Photo photo);

        Task UpdateAsync(Photo photo);

        Task RemoveRangeAsync(IEnumerable<Photo> photos);
    }
}

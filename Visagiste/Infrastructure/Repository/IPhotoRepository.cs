using System.Collections.Generic;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> Photos { get; }

        Photo GetPhoto(long id);

        void AddPhoto(Photo photo);

        void UpdatePhoto(Photo photo);

        void DeletePhoto(Photo photo);
    }
}

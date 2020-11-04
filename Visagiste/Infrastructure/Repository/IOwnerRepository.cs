using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public interface IOwnerRepository
    {
        Owner Get();

        void Add(Owner owner);

        void Update(Owner owner);
    }
}

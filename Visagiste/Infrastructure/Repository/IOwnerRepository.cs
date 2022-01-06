using System.Threading.Tasks;
using Visagiste.Models;

namespace Visagiste.Infrastructure.Repository
{
    public interface IOwnerRepository
    {
        Task<Owner> GetAsync();

        Task AddAsync(Owner owner);

        Task UpdateAsync(Owner owner);
    }
}

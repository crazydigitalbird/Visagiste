using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Components
{
    public class Footer : ViewComponent
    {
        private IOwnerRepository ownerRepository;

        public Footer(IOwnerRepository ownerRepo)
        {
            ownerRepository = ownerRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Owner owner = await ownerRepository.GetAsync();
            return View(owner);
        }
    }
}
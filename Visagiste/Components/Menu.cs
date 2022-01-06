using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Components
{
    public class Menu : ViewComponent
    {
        private readonly IOwnerRepository ownerRepository;

        public Menu(IOwnerRepository ownerRepository) => this.ownerRepository = ownerRepository;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Owner owner = await ownerRepository.GetAsync();
            return View(owner);
        }
    }
}

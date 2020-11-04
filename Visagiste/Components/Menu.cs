using Microsoft.AspNetCore.Mvc;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Components
{
    public class Menu : ViewComponent
    {
        private readonly IOwnerRepository ownerRepository;

        public Menu(IOwnerRepository ownerRepository) => this.ownerRepository = ownerRepository;
        public IViewComponentResult Invoke()
        {
            Owner owner = ownerRepository.Get();
            return View(owner);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Visagiste.Infrastructure.Repository;

namespace Visagiste.Components
{
    public class Footer : ViewComponent
    {
        private IOwnerRepository ownerRepository;

        public Footer(IOwnerRepository ownerRepo)
        {
            ownerRepository = ownerRepo;
        }

        public IViewComponentResult Invoke()
        {
            return View(ownerRepository.Get());
        }
    }
}
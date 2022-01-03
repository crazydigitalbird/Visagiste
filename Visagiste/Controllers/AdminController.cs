using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private IOwnerRepository ownerRepository;

        public AdminController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        public IActionResult Index()
        {
            Owner owner = ownerRepository.Get();

            return View(owner);
        }

        [HttpPost]
        public IActionResult Index(Owner owner, IFormFile avatarFile)
        {
            if (ModelState.IsValid)
            {
                if (avatarFile != null)
                {
                    owner.Avatar.Update(avatarFile);
                }
                ownerRepository.Update(owner);
                TempData["message"] = "Owner information has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            Owner owner = await ownerRepository.GetAsync();

            return View(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Owner owner, IFormFile avatarFile)
        {
            if (ModelState.IsValid)
            {
                if (avatarFile != null)
                {
                    owner.Avatar.Update(avatarFile);
                }
                await ownerRepository.UpdateAsync(owner);
                TempData["message"] = "Owner information has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }
    }
}

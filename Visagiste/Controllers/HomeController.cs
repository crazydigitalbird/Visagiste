using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Controllers
{
    public class HomeController : Controller
    {
        private IOwnerRepository ownerRepository;
        private IPhotoRepository photoRepository;

        public HomeController(IOwnerRepository ownerRepository, IPhotoRepository photoRepository)
        {
            this.ownerRepository = ownerRepository;
            this.photoRepository = photoRepository;
        }

        public async Task<IActionResult> Index()
        {
            Owner owner = await ownerRepository.GetAsync();
            return View(owner);
        }

        public IActionResult Collection()
        {
            return View(photoRepository.Photos);
        }

        public async Task<IActionResult> About()
        {
            Owner owner = await ownerRepository.GetAsync();
            return View(owner);
        }

        public IActionResult Services()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            Owner owner = await ownerRepository.GetAsync();
            return View(owner.Contact);
        }
    }
}

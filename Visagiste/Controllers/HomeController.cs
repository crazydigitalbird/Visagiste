using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            Owner owner = ownerRepository.Get();
            return View(owner);
        }

        public IActionResult Collection()
        {
            return View(photoRepository.Photos);
        }

        public IActionResult About()
        {
            Owner owner = ownerRepository.Get();
            return View(owner);
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}

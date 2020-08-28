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
        private IPhotoRepository photoRepository;

        public HomeController(IPhotoRepository photoRepo)
        {
            photoRepository = photoRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Collection()
        {
            return View(photoRepository.Photos);
        }

        public IActionResult About()
        {
            return View();
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

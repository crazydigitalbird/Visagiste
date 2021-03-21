using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Controllers
{
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
        public IActionResult Index(Owner owner)
        {
            if (ModelState.IsValid)
            {
                ownerRepository.Update(owner);
                TempData["message"] = "Owner information has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }
    }
}

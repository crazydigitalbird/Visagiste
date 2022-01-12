using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly IOwnerRepository ownerRepository;

        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminController(IOwnerRepository ownerRepository, IWebHostEnvironment webHostEnv)
        {
            this.ownerRepository = ownerRepository;
            this.webHostEnvironment = webHostEnv;
        }

        public async Task<IActionResult> Index()
        {
            Owner owner = await ownerRepository.GetAsync();
            if (owner?.Avatar?.Image != null)
            {
                ViewBag.BackgroundImage = $"background-image: url('data:image/jpeg;base64,{Convert.ToBase64String(owner.Avatar.Image)}'); " +
                                          $"background-position: {owner.Avatar.X}px {owner.Avatar.Y}px;";
            }
            return View(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Owner owner, IFormFile avatarFile, IFormFile bannerOne, IFormFile bannerTwo)
        {
            if (ModelState.IsValid)
            {
                owner.Avatar.Image = await GetByteArrayFormFile(avatarFile);
                await SaveFile("banner-1.jpg", bannerOne);
                await SaveFile("banner-2.jpg", bannerTwo);

                await ownerRepository.UpdateAsync(owner);
                TempData["message"] = "Owner information has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        private async Task<byte[]> GetByteArrayFormFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await formFile.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }

        private async Task SaveFile(string fileName, IFormFile formFile)
        {
            byte[] buffer = await GetByteArrayFormFile(formFile);
            if(buffer != null)
            {
                string fullFileName = Path.Combine(webHostEnvironment.WebRootPath, "images", "SeedData", fileName);
                await System.IO.File.WriteAllBytesAsync(fullFileName, buffer);
            }
        }
    }
}

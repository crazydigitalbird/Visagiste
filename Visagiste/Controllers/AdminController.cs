using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly IPhotoRepository photoRepository;

        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly ApplicationDbContext applicationDbContext;

        public AdminController(IOwnerRepository ownerRepository, IPhotoRepository photoRepository, IWebHostEnvironment webHostEnvironment, ApplicationDbContext applicationDbContext)
        {
            this.ownerRepository = ownerRepository;
            this.photoRepository = photoRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.applicationDbContext = applicationDbContext;
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
                await SaveFile(Path.Combine("images", "SeedData", "banner-1.jpg"), bannerOne);
                await SaveFile(Path.Combine("images", "SeedData", "banner-2.jpg"), bannerTwo);

                await ownerRepository.UpdateAsync(owner);
                TempData["message"] = "Owner information has been successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        public IActionResult Collection()
        {
            return View(photoRepository.Photos);
        }

        public IActionResult AddPhoto()
        {
            PhotoViewModel photoViewModel = new PhotoViewModel
            {
                Tags = applicationDbContext.Tags.ToList(),
            };
            return View("EditPhoto", photoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(PhotoViewModel photoViewModel)
        {
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(photoViewModel.FormFile.FileName);
                string fileName = $"{Path.Combine(Guid.NewGuid().ToString())}{extension}";
                string fullFileName = Path.Combine("images", fileName);
                await SaveFile(fullFileName, photoViewModel.FormFile);
                Photo newPhoto = new Photo() { Name = fileName, PhotoTags = photoViewModel.SelectedTags?.Select(id => new PhotoTagJunction { TagId = id }).ToList() };
                await photoRepository.AddAsync(newPhoto);
                return RedirectToAction(nameof(Collection));
            }
            return View("EditPhoto", photoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePhotos(IEnumerable<int> photosId)
        {
            if (photosId.Count() > 0)
            {
                List<Photo> photos = new List<Photo>();
                foreach (int id in photosId)
                {
                    var photo = photoRepository.Get(id);
                    if (photo != null)
                    {
                        string fullName = Path.Combine(webHostEnvironment.WebRootPath, "images", photo.Name);
                        try
                        {
                            System.IO.File.Delete(fullName);
                            photos.Add(photo);
                        }
                        catch(Exception ex)
                        {
                            //TODO: Log
                        }
                    }
                }
                await photoRepository.RemoveRangeAsync(photos);
            }
            return RedirectToAction(nameof(Collection));
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
            if (buffer != null)
            {
                string fullFileName = Path.Combine(webHostEnvironment.WebRootPath, fileName);
                await System.IO.File.WriteAllBytesAsync(fullFileName, buffer);
            }
        }
    }
}

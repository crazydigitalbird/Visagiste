using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Components
{
    public class Menu : ViewComponent
    {
        private readonly IOwnerRepository ownerRepository;

        public Menu(IOwnerRepository ownerRepository) => this.ownerRepository = ownerRepository;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Owner owner = await ownerRepository.GetAsync();
            if(owner?.Avatar?.Image != null)
            {
                ViewBag.BackgroundImage = $"background-image: url('data:image/jpeg;base64,{Convert.ToBase64String(owner.Avatar.Image)}'); " +
                                          $"background-position: {owner.Avatar.X}px {owner.Avatar.Y}px;";
            }
            return View(owner);
        }
    }
}

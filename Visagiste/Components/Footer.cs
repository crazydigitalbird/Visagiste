﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        public async Task<IViewComponentResult> Invoke()
        {
            return View(await ownerRepository.GetAsync());
        }
    }
}
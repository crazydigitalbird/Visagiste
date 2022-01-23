using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Visagiste.Infrastructure.Repository;
using Visagiste.Models;

namespace Visagiste.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public TagController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var tags = applicationDbContext.Set<Tag>();
            return View(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                var tags = applicationDbContext.Tags.Where(t => t.Name.ToLower() == tag.Name.ToLower());
                if (tags?.Count() == 0)
                {
                    await applicationDbContext.Tags.AddAsync(tag);
                    await applicationDbContext.SaveChangesAsync();
                }
                else
                {
                    TempData["Error"] = $"'{tag.Name}' name tag already exist.";
                }
            }
            else
            {
                TempData["Error"] = "The Tag Name field is required.";
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Save(Tag tag)
        {
            if(ModelState.IsValid)
            {
                applicationDbContext.Tags.Update(tag);
                await applicationDbContext.SaveChangesAsync();
            }
            else
            {
                TempData["Error"] = "The Tag Name field is required.";
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Tag tag = await applicationDbContext.FindAsync<Tag>(id);
            if(tag != null)
            {
                applicationDbContext.Tags.Remove(tag);
                await applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

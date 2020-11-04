using Microsoft.AspNetCore.Mvc;

namespace Visagiste.Components
{
    public class Instagram : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

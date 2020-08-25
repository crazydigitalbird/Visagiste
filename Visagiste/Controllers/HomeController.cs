using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Visagiste.Models;

namespace Visagiste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Collection()
        {
            IEnumerable<Photo> photos = new List<Photo>() {
                new Photo(){Url = "/images/image_1.jpg", Tags = new List<string>{"Model", "Visagiste" } },
                new Photo(){Url ="/images/image_2.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_3.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_4.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_5.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_6.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_7.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_8.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_9.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_10.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_11.jpg", Tags = new List<string>{ "Model"} },
                new Photo(){Url ="/images/image_12.jpg", Tags = new List<string>{ "Model"} }
,            };

            return View(photos);
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

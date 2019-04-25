using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gahfour_web_shop_2.Controllers
{
    public class ApplicationKeysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerateKeys()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateKeysPost()
        {
            return View();
        }
    }
}
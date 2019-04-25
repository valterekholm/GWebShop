using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gahfour_web_shop_2.Models;
using Gahfour_web_shop_2.Repository;
using Microsoft.AspNetCore.Http;

namespace Gahfour_web_shop_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepo _itemRepo;
        private readonly ISettingsRepo _settingsRepo;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public HomeController(IItemRepo itemRepo, ISettingsRepo settingsRepo, IHttpContextAccessor httpContextAccessor)/*IHttpContextAccessor httpContextAccessor*/
        {
            _itemRepo = itemRepo;
            _settingsRepo = settingsRepo;
            _httpContextAccessor = httpContextAccessor;
            //this.session = httpContextAccessor.HttpContext.Session;
        }
        public ActionResult Index()
        {
            //get settings:
            ViewData["imgFolder"] = HttpContext.Request.PathBase + "/images";
            ViewData["useTableGrid"] = _settingsRepo.useTableGrid();
            ViewData["currency"] = _settingsRepo.getCurrency();


            _session.SetString("Name", "Abdullah");
            ViewData["name"] = _session.GetString("Name");


            var items = _itemRepo.GetItemsPage(1, 10);

            return View(items);
        }

        public PartialViewResult Items(bool useTable, int page)
        {//not in use while table layout used
            var useTableGrid = _settingsRepo.useTableGrid();
            List<Item> items = _itemRepo.GetItemsPage(page, 5);//todo: setup perPage in settings db
            if(useTableGrid)
            {
                return PartialView("_Items", items);
            }
            else
            {
                return PartialView("_ItemsDivs", items);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetUserName(string userName, string )
        {
            ViewData["userName"] = userName;

        }

        [HttpGet]
        [Route("Home/GetColsFromWidth/{width}")]
        public IActionResult GetColsFromWidth(int width)
        {
            int colWidth = 260;
            int colMargin = 24;
            int sectionPadding = 20;
            ViewData["cols"] = (int)width / (colWidth+colMargin+sectionPadding);
            return View();
        }

        [HttpGet]
        public ActionResult AjaxGetCols(int width, int contentWidth, string unit)
        {
            int colWidth = 260;//Item image... TODO: set up in admin db
            int colMargin = 24;
            int sectionPadding = 20;
            switch (unit)
            {
                case "percent":
                    contentWidth = (int)(width * (contentWidth / (double)100));
                    break;
                case "px":
                    break;
                default:
                    break;
            }
            var myW = contentWidth / (colWidth+colMargin+sectionPadding);
            //HttpContext.Session.SetString("myCols", Convert.ToString(myW));
            //var c = HttpContext.Session.GetString("myCols");
            //var u = HttpContext.Session.GetString("useTableGrid");

            return Json(myW);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

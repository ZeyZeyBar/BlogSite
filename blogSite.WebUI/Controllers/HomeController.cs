using blogSite.Core.Service;
using blogSite.Model.Entities;
using blogSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace blogSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoreService<About> _aboutDb;
        private readonly ICoreService<FormContact> _formContactDb;
        public HomeController(ILogger<HomeController> logger, ICoreService<About> aboutDb, ICoreService<FormContact> formContactDb)
        {
            _logger = logger;
            _aboutDb = aboutDb;
            _formContactDb = formContactDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //var about =_aboutDb.GetAll();
            // return View(about);
            return View();
        }
        public IActionResult Contact() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendForm(FormContact formTable)
        {
            if (!string.IsNullOrEmpty(formTable.NameSurname) && !string.IsNullOrEmpty(formTable.Message))
            {
                if (_formContactDb.Add(formTable))
                {
                    TempData["FormStatus"] = "success";
                }
                else
                {
                    TempData["FormStatus"] = "error";
                }
            }
            else
            {
                TempData["FormStatus"] = "error";
            }

            return RedirectToAction("Contact");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

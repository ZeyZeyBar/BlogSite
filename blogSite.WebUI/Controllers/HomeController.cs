using blogSite.Core.Service;
using blogSite.Model.Entities;
using blogSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace blogSite.WebUI.Controllers
{
    //ADMIN SAYFA İÇERİĞİ DZENLENECKE, LOGIN SAYFASI DÜZENLENECEK. 
    //RESIM EKLEME YAPISI İSTEĞE BAĞLI YKLENECEK.
    //ÜRÜN DETAY SAYFASI EKLENECEK.
    //LİNK VERME SHOPIER VS. EKLENECEK.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoreService<About> _aboutDb;
        private readonly ICoreService<FormContact> _formContactDb;
        private readonly ICoreService<HomeDetail> _homeDetailDb;
        public HomeController(ILogger<HomeController> logger, ICoreService<About> aboutDb, ICoreService<FormContact> formContactDb, ICoreService<HomeDetail> homeDetailDb)
        {
            _logger = logger;
            _aboutDb = aboutDb;
            _formContactDb = formContactDb;
            _homeDetailDb = homeDetailDb;
        }

        public IActionResult Index()
        {
            var content = _homeDetailDb.GetAll();
            if (content != null)
            {
                var activeContent = content
                    .Where(a => a.IsActive)
                    .OrderByDescending(a => a.ID).ToList();
                return View(activeContent);
            }
            return View();
        }

        public IActionResult About()
        {
            var about =_aboutDb.GetAll();
            if(about !=null)
            {
                var activeAbout = about
                    .Where(a => a.IsActive)
                    .OrderByDescending(a => a.ID)
                    .FirstOrDefault();
               return View(activeAbout);   
            }
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

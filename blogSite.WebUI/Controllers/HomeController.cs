using blogSite.Core.Service;
using blogSite.Model.Entities;
using blogSite.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace blogSite.WebUI.Controllers
{
  
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

        public IActionResult Index(int page = 1)
        {
            int pageSize = 3;

            var allContent = _homeDetailDb.GetAll()
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.ID)
                .ToList();

            var pagedContent = allContent
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.HasMore = allContent.Count > page * pageSize;

            return View(pagedContent);
        }

        [HttpGet]
        public IActionResult UpdateContent(int id)
        {
            var content = _homeDetailDb.GetById(id);

            if (content == null)
            {
                return NotFound(); // bulunamazsa 404 döndür
            }
            // bulundu, View'a Model olarak gönderiyoruz
            return View(content);

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
        [HttpGet]
        public IActionResult ContentDetail(int id)
        {
            var content = _homeDetailDb.GetById(id);

            if (content == null)
            {
                return NotFound(); // bulunamazsa 404 döndür
            }
            // bulundu, View'a Model olarak gönderiyoruz
            return View(content);
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

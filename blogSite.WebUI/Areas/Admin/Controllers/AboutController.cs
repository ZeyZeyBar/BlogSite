using blogSite.Core.Service;
using blogSite.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly ICoreService<About> _aboutDb;

        public AboutController(ICoreService<About> aboutDb)
        {
            _aboutDb = aboutDb;           
        }
        public IActionResult GetAllAboutList()
        {
           var about = _aboutDb.GetAll();
            return View(about);
           // return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            if (ModelState.IsValid)
            {
                about.CreateTime = DateTime.Now;
               // adminUser.UserRoles = adminUser.UserRoles?.Any() == true ? adminUser.UserRoles : new List<UserRole>();
                var result = _aboutDb.Add(about);
                if (result)
                {
                    TempData["SuccesMessage"] = "Hakkında içeriği başarılı bir şekilde eklendi.";
                    return RedirectToAction("GetAllAboutList");
                }
                else
                {
                    TempData["ErrorMessage"] = "Hata oluştu tekrar deneyin";
                }
            }
            else
            {
                // Eğer model geçerli değilse, ModelState hatalarını logla
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Hata: {error.ErrorMessage}");
                }
            }
            return View(about);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAbout(int id, About aboutnew)
        {
            var about=_aboutDb.GetById(id);
            if (aboutnew !=null)
            {                
                about.UpdateTime = DateTime.Now;
                about.Title = aboutnew.Title;
                about.Description = aboutnew.Description;
                about.IsActive=aboutnew.IsActive;    

                var result = _aboutDb.Update(about);
                if (result)
                {
                    TempData["SuccesMessage"] = "Hakkında içeriği başarılı bir şekilde güncellendi.";
                    return RedirectToAction("GetAllAboutList");
                }
                else
                {
                    TempData["ErrorMessage"] = "Hata oluştu tekrar deneyin";
                }
            }
            else
            {
                // Eğer model geçerli değilse, ModelState hatalarını logla
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Hata: {error.ErrorMessage}");
                }
            }
            return View(about); ;
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _aboutDb.GetById(id);

            if (about == null)
            {
                return NotFound(); // bulunamazsa 404 döndür
            }
            // bulundu, View'a Model olarak gönderiyoruz
            return View(about);
           
        }
    }
}
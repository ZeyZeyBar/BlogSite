using blogSite.Core.Service;
using blogSite.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ContentCreatorController : Controller
    {
        private readonly ICoreService<HomeDetail> _hdetailDb;

        public ContentCreatorController(ICoreService<HomeDetail> hdetailDb)
        {
            _hdetailDb = hdetailDb;
        }
        public IActionResult GetAllContent()
        {
            var content = _hdetailDb.GetAll();
            return View(content);
        }
        [HttpPost]
        public IActionResult AddContent(HomeDetail content)
        {
            if (ModelState.IsValid)
            {
                content.CreateTime = DateTime.Now;
                
                var result = _hdetailDb.Add(content);
                if (result)
                {
                    TempData["SuccesMessage"] = "Ana Sayfa içeriği başarılı bir şekilde eklendi.";
                    return RedirectToAction("GetAllContent");
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
            return View(content);
        }
        [HttpGet]
        public IActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateContent(int id, HomeDetail contentNew)
        {
            var content = _hdetailDb.GetById(id);
            if (contentNew != null)
            {
                content.UpdateTime = DateTime.Now;
                content.Title = contentNew.Title;
                content.Details = contentNew.Details;
                content.IsActive = contentNew.IsActive;

                var result = _hdetailDb.Update(content);
                if (result)
                {
                    TempData["SuccesMessage"] = "Ana Sayfa içeriği başarılı bir şekilde güncellendi.";
                    return RedirectToAction("GetAllContent");
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
            return View(content); ;
        }
        [HttpGet]
        public IActionResult UpdateContent(int id)
        {
            var content = _hdetailDb.GetById(id);

            if (content == null)
            {
                return NotFound(); // bulunamazsa 404 döndür
            }
            // bulundu, View'a Model olarak gönderiyoruz
            return View(content);

        }

    }
}

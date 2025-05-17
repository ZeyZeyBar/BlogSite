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
        public IActionResult AddContent(HomeDetail content, IFormFile uploadedImage)
        {
            if (ModelState.IsValid)
            {
                content.CreateTime = DateTime.Now;
                byte[] imageBytes;
                using (var memoryStream = new MemoryStream())
                {
                    uploadedImage.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
                content.Image = imageBytes;
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
        public IActionResult UpdateContent(int id, HomeDetail contentNew, IFormFile uploadedImage)
        {
            var content = _hdetailDb.GetById(id);
            if (contentNew != null)
            {
                content.UpdateTime = DateTime.Now;
                content.Title = contentNew.Title;
                content.Details = contentNew.Details;
                content.IsActive = contentNew.IsActive;
                if (uploadedImage != null && uploadedImage.Length > 0)
                {
                    // Resim byte[]'e dönüştürülür ve işlenir.
                    byte[] imageBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        uploadedImage.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();
                    }

                    // Mevcut resmi güncelleyin veya başka bir işlem yapın.
                    content.Image = imageBytes;
                }
                else
                {
                    // Resim gönderilmediyse mevcut durumu koruyun.
                    // Mevcut işleminize göre burayı düzenleyebilirsiniz.
                }
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
      
        }

    }

using blogSite.Core.Service;
using blogSite.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ICoreService<User> _userDb;

        public UserController(ICoreService<User> userDb)
        {
            _userDb = userDb;              
        }
        public IActionResult GetAllUser()
        {
            var user = _userDb.GetAll();
            return View(user);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.CreateTime = DateTime.Now;
                // adminUser.UserRoles = adminUser.UserRoles?.Any() == true ? adminUser.UserRoles : new List<UserRole>();
                var result = _userDb.Add(user);
                if (result)
                {
                    TempData["SuccesMessage"] = "Yeni Kullanıcı başarılı bir şekilde eklendi.";
                    return RedirectToAction("GetAllUser");
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
            return View(user);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(int id, User usernew)
        {
            var user = _userDb.GetById(id);
            if (usernew != null)
            {
                user.UpdateTime = DateTime.Now;
                user.Name = usernew.Name;
                user.Surname = usernew.Surname;
                user.UserName = usernew.UserName;
                user.Password = usernew.Password;
                user.IsActive = usernew.IsActive;
                    

                var result = _userDb.Update(user);
                if (result)
                {
                    TempData["SuccesMessage"] = "Kullanıcı içeriği başarılı bir şekilde güncellendi.";
                    return RedirectToAction("GetAllUser");
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
            return View(user); ;
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = _userDb.GetById(id);

            if (user == null)
            {
                return NotFound(); // bulunamazsa 404 döndür
            }
            // bulundu, View'a Model olarak gönderiyoruz
            return View(user);

        }
    }
}
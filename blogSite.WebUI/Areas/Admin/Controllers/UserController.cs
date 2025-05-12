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
    }
}
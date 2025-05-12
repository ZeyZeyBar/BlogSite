using blogSite.Core.Service;
using blogSite.Model.Entities;
using blogSite.WebUI.Areas.Admin.Models;
using blogSite.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace blogSite.WebUI.Controllers
{
    public class AdminAccountInController : Controller
    {
        private readonly ICoreService<User> _userDb;
        public AdminAccountInController(ICoreService<User> userDb)
        {
            _userDb = userDb;
        }
        [HttpGet]
        public IActionResult Login()
        {
            //ViewData["ReturnUrl"] = returnUrl ?? "/";
            return View();
        }
        [HttpPost]

       public async Task<IActionResult> LoginAsync(LoginView model, string returnUrl = null)
        {
            if (model != null)
            {
                var user = _userDb
                            .GetAll()
                            .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                if (user != null && user.IsActive == true)
                {
                      // claims(talepler)
                   var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, model.UserName)
                    };
                    // identity oluşturma
                     var users = new ClaimsIdentity(claims, "Login");
                    // Prensip(Özellik) oluşturma
                    ClaimsPrincipal principal = new ClaimsPrincipal(users);

                    await HttpContext.SignInAsync(principal); // Login oluyoruz
                     var username = principal.Identity.Name;

                     if ((username) != null)
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                 }
                else
                {
                    return RedirectToAction("AccessDenied");
                }
            }
            return View();
        }

        public IActionResult Welcome()
        {
            var username = Request.Cookies["UserName"];

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Index", "Home");

            ViewBag.Email = username;
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("username");
            return RedirectToAction("Login");
        }
    }
}

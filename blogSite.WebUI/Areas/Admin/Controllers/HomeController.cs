using blogSite.Core.Service;
using blogSite.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICoreService<About> _aboutDb;
        private readonly ICoreService<User> _userDb;
        public IActionResult Index()
        {
          //  var username = PriorityQueue;

            //if (string.IsNullOrEmpty(userName))
            //{
            //    return RedirectToAction("Login", "Account");  // Login sayfasına yönlendirme
            //}

          //  ViewBag.UserName = username;
            return View();
        }
    }
}

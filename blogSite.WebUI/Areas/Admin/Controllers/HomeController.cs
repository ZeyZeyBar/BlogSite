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
        private readonly ICoreService<FormContact> _formDb;

        public HomeController(ICoreService<About> aboutDb, ICoreService<User> userDb,ICoreService<FormContact> formDb)
        {
            _aboutDb = aboutDb;
            _formDb = formDb;
            _userDb = userDb;

        }
        public IActionResult Index()
        {
            //  var username = PriorityQueue;

            //if (string.IsNullOrEmpty(userName))
            //{
            //    return RedirectToAction("Login", "Account");  // Login sayfasına yönlendirme
            //}

            //  ViewBag.UserName = username;
            var comeIngMessageCounts = _formDb.GetAll();
             
            return View(comeIngMessageCounts);
        }
    }
}

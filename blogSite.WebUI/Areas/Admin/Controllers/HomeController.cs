using blogSite.Core.Service;
using blogSite.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICoreService<About> _aboutDb;
        private readonly ICoreService<User> _userDb;
        public IActionResult Index()
        {
            return View();
        }
    }
}

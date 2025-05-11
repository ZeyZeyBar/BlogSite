using blogSite.Core.Service;
using blogSite.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactFormController : Controller
    {      
        private readonly ICoreService<FormContact> _contactFormDb;
        public ContactFormController(ICoreService<FormContact> contactFormDb)
        {
            _contactFormDb = contactFormDb;                
        }
        public IActionResult GetAllMessages()
        {
            var messages = _contactFormDb.GetAll();
            return View(messages);
        }
    }
}

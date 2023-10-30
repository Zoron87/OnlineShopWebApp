using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        public ActionResult GetUsers()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

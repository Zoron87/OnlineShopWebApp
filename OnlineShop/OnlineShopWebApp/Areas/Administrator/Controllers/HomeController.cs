using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

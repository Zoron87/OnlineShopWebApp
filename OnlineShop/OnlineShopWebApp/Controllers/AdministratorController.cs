using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrders()
        {
            return View("GetOrders");
        }

        public ActionResult GetUsers()
        {
            return View("GetUsers");
        }

        public ActionResult GetRoles()
        {
            return View("GetRoles");
        }

        public ActionResult GetProducts()
        {
            return View("GetProducts");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Registration(Register registerInfo)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

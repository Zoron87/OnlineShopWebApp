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

        public ActionResult Registration(Login authorizationData)
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            return View("Success");
        }

        [HttpPost]
        public ActionResult PostRegistration(Login authorizationData)
        {
            return View("Success");
        }
    }
}

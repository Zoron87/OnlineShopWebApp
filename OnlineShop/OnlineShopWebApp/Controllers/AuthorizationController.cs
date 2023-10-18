using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Authorization(User user) 
        //{
        //    return userStorage.Login(user) ? View("SuccessAuthorization") : View("Error");
        //}

        //[HttpPost]
        //public ActionResult Registration(User user)
        //{
        //    return userStorage.Registration(user) ? View("SuccessRegistration") : View("Error");
        //}
    }
}

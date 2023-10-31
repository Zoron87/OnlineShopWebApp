using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        private readonly IUserStorage userStorage;

        public UserController(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }
        public ActionResult GetUsers()
        {
            var users = userStorage.GetAll();
            return View(users);
        }

        public ActionResult Delete(string Email)
        {
            userStorage.Remove(Email);
            return RedirectToAction("GetUsers");
        }
    }
}

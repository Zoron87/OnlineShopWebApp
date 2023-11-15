using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        private readonly IUserStorage userStorage;
        private readonly IRoleStorage roleStorage;

        public UserController(IUserStorage userStorage, IRoleStorage roleStorage)
        {
            this.userStorage = userStorage;
            this.roleStorage = roleStorage;
        }
        public ActionResult Index()
        {
            var users = userStorage.GetAll();
            return View(users);
        }

        public ActionResult Delete(string email)
        {
            userStorage.Delete(email);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Register registerInfo)
        {
            if (registerInfo.Email == registerInfo.Password)
                ModelState.AddModelError("", "Email и пароль не должны совпадать");

            if (registerInfo.Password != registerInfo.ConfirmPassword)
                ModelState.AddModelError("", "Пароли не совпадают");

            if (String.IsNullOrEmpty(registerInfo.Password) || String.IsNullOrEmpty(registerInfo.ConfirmPassword))
                ModelState.AddModelError("", "Пароль не может быть пустым");

            if (userStorage.GetAll().Any(u => u.Email == registerInfo.Email))
            {
                ModelState.AddModelError("Email", "Такой email уже зарегистрирован. Используйте другой");
            }

            if (ModelState.IsValid)
            {
                userStorage.Add(registerInfo);
                return RedirectToAction("Index");
            }
            return View(registerInfo);
        }

        public IActionResult Details(string Email)
        {
            var user = userStorage.TryGetByEmail(Email);
            return View(user);
        }

        public IActionResult Edit(string Email)
        {
            var user = userStorage.TryGetByEmail(Email);
            ViewBag.Role = new SelectList(roleStorage.GetAll().AsEnumerable(), "Name", "Name");
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(ShopUser shopUser)
        {
            if (ModelState.IsValid)
            {
                userStorage.Edit(shopUser);
                return RedirectToAction("Index");
            }
            return View(shopUser);
        }
    }
}

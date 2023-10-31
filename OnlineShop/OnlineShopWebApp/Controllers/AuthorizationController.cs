using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserStorage userStorage;

        public AuthorizationController(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            if (!userStorage.CheckExistUser(loginInfo))
            {
                ModelState.AddModelError("", "Пользователь с таким email или паролем не найден!");
            }

            if (ModelState.IsValid)
            {
                ViewData["UserEmail"] = loginInfo.Email;
                return View("Success");
            }
            return View(loginInfo);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Register registerInfo)
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
                ViewData["UserEmail"] = registerInfo.Email;
                return View("Success");
            }
            return View(registerInfo);
        }
    }
}

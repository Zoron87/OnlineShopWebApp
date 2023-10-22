using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");
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

            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            return View(registerInfo);
        }
    }
}

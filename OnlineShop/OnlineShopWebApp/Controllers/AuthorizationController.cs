using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        //private readonly IUserStorage userStorage;
        //private readonly IUsersManager usersManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;  // для хранения кук

        public AuthorizationController(SignInManager<User> signInManager, UserManager<User> userInManager)
        {
            //this.usersManager = usersManager;
            _signInManager = signInManager;
            _userManager = userInManager;
            //this.userStorage = userStorage;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, loginInfo.IsRememberMe, false).Result;
                if (result.Succeeded)
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                else ModelState.AddModelError("", "Неправильный пароль");
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

            //if (userStorage.GetAll().Any(u => u.Email == registerInfo.Email))
            //{
            //    ModelState.AddModelError("Email", "Такой email уже зарегистрирован. Используйте другой");
            //}

            if (ModelState.IsValid)
            {
                //userStorage.Add(registerInfo);
                ViewData["UserEmail"] = registerInfo.Email;
                return View("Success");
            }
            return View(registerInfo);
        }
    }
}

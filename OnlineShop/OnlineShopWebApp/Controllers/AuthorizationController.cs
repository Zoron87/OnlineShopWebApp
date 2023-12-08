using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;  // для хранения кук

        public AuthorizationController(SignInManager<User> signInManager, UserManager<User> userInManager)
        {
            _signInManager = signInManager;
            _userManager = userInManager;
        }
        public ActionResult Login(string returnUrl)
        {
            return View(new Login() {ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Login(Login loginInfo)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, loginInfo.IsRememberMe, false).Result;
                if (result.Succeeded)
                    return Redirect(loginInfo.ReturnUrl ?? "/Home");
                else 
                    ModelState.AddModelError("", "Неправильный пароль");
            }
            return View(loginInfo);
        }

        public ActionResult Registration(string returnUrl)
        {
            return View(new Register() {ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Registration(Register registerInfo)
        {
            var checkEmail = _userManager.FindByEmailAsync(registerInfo.Email).Result;
            if (checkEmail != null)
                ModelState.AddModelError("Email", "Данный email уже используется. Укажите другой!");

            if (registerInfo.Email == registerInfo.Password)
                ModelState.AddModelError("", "Email и пароль не должны совпадать");

            if (registerInfo.Password != registerInfo.ConfirmPassword)
                ModelState.AddModelError("", "Пароли не совпадают");

            if (String.IsNullOrEmpty(registerInfo.Password) || String.IsNullOrEmpty(registerInfo.ConfirmPassword))
                ModelState.AddModelError("", "Пароль не может быть пустым");

            if (ModelState.IsValid)
            {
                var user = new User { Email = registerInfo.Email, UserName = registerInfo.Email, Role = Constants.UserRoleName, AvatarImagepath = Constants.BlankAvatar };
                var result = _userManager.CreateAsync(user, registerInfo.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    _userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
                    return Redirect(registerInfo.ReturnUrl ?? "/Home");
                }
                else
                    ModelState.AddModelError("", String.Join("\r\n", result.Errors.Select(e => e.Description)));
            }
            return View(registerInfo);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;  // для хранения кук
        private readonly UserViewModel _userViewModel;
        private readonly IFavouriteStorage _favouriteStorage;
        private readonly ICompareStorage _compareStorage;
        private readonly ICartStorage _cartDBStorage;

        public AuthorizationController(SignInManager<User> signInManager, UserManager<User> userManager, UserViewModel userViewModel, ICartStorage cartDBStorage)
        {
            _signInManager = signInManager;
            _userViewModel = userViewModel;
            _cartDBStorage = cartDBStorage;
            _userManager = userManager;
        }
        public  IActionResult Login(string returnUrl)
        {
            return View(new Login() {ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login loginInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, loginInfo.IsRememberMe, false);
                if (result.Succeeded)
                    return Redirect("/Home");
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
        public async Task<IActionResult> RegistrationAsync(Register registerInfo)
        {
            var checkEmail = await _userManager.FindByEmailAsync(registerInfo.Email);
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
                var result = await _userManager.CreateAsync(user, registerInfo.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false); 
                    await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    return Redirect("/Home");
                }
                else
                    ModelState.AddModelError("", String.Join("\r\n", result.Errors.Select(e => e.Description)));
            }
            return View(registerInfo);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

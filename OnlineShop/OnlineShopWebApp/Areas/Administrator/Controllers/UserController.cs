using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public ActionResult Delete(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            _userManager.DeleteAsync(user).Wait();
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

            if (_userManager.Users.Any(u => u.Email == registerInfo.Email))
            {
                ModelState.AddModelError("Email", "Такой email уже зарегистрирован. Используйте другой");
            }

            if (ModelState.IsValid)
            {
                var user = new User() { Email = registerInfo.Email, UserName = registerInfo.Email, Role = Constants.UserRoleName };
                var result = _userManager.CreateAsync(user, registerInfo.Password).Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", String.Join("\r\n", result.Errors.Select(e => e.Description)));
            }
            return View(registerInfo);
        }

        public IActionResult Details(string Email)
        {
            var user = _userManager.FindByEmailAsync(Email).Result;
            return View(user);
        }

        public IActionResult Edit(string Email)
        {
            var user = _userManager.FindByEmailAsync(Email).Result;
            ViewBag.Role = new SelectList(_roleManager.Roles.AsEnumerable(), "Name", "Name");

            var userViewModel = new UserViewModel();
            userViewModel.Id = new Guid(user.Id.ToString());
            userViewModel.Name = user.UserName;
            userViewModel.Email = user.Email;
            userViewModel.Password = user.PasswordHash;
            userViewModel.Role = user.Role;

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(userViewModel.Id.ToString()).Result;
                if (user != null)
                {
                    user.UserName = userViewModel.Name;
                    user.Email = userViewModel.Email;

                    if (user.PasswordHash != userViewModel.Password)
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userViewModel.Password);

                    if (user.Role != userViewModel.Role && userViewModel.Role != null)
                    {
                        _userManager.RemoveFromRoleAsync(user, user.Role).Wait();
                        _userManager.AddToRoleAsync(user, userViewModel.Role).Wait();
                        user.Role = userViewModel.Role;
                    }
                    var result = _userManager.UpdateAsync(user).Result;
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                }
            }
            return View(userViewModel);
        }
    }
}

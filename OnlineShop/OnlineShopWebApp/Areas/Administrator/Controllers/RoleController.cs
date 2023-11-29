using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<UserRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            var rolesViewModel = _roleManager.Roles.ToList().ToRoleViewModel();
            return View(rolesViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RoleViewModel roleViewModel)
        {
            var roles = _roleManager.Roles.ToList();
            if (roles.Any(r => r.Name.ToLower() == roleViewModel.Name.ToString().ToLower()))
                ModelState.AddModelError("Name", $"Роль {roleViewModel.Name} уже существует");

            if (ModelState.IsValid)
            {
                _roleManager.CreateAsync(new UserRole(roleViewModel.Name, roleViewModel.Description)).Wait();
                return RedirectToAction("Index");
            }
            return View(roleViewModel);
        }

        public ActionResult Delete(RoleViewModel roleViewModel)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == roleViewModel.Name);
            var user = _userManager.Users.FirstOrDefault(u => u.Role == roleViewModel.Name);

            if (user != null) 
            {
                var RolesViewModel = new List<RoleViewModel>();
                ModelState.AddModelError("", $"У роли {roleViewModel.Name} есть привязки к пользователям.");
                throw new Exception($"У роли {roleViewModel.Name} есть привязки к пользователям.");
            }

            _roleManager.DeleteAsync(role).Wait();
            return RedirectToAction("Index");
        }
    }
}

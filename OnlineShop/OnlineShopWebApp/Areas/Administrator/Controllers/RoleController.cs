using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<UserRole> roleManager, UserManager<User> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesViewModel = _mapper.Map<List<RoleViewModel>>(roles);
            return View(rolesViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleViewModel roleViewModel)
        {
            var roles = _roleManager.Roles.ToList();
            if (roles.Any(r => r.Name.ToLower() == roleViewModel.Name.ToString().ToLower()))
                ModelState.AddModelError("Name", $"Роль {roleViewModel.Name} уже существует");

            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(new UserRole(roleViewModel.Name, roleViewModel.Description));
                return RedirectToAction("Index");
            }
            return View(roleViewModel);
        }

        public async Task<IActionResult> Delete(RoleViewModel roleViewModel)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == roleViewModel.Name);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Role == roleViewModel.Name);

            if (user != null) 
            {
                var RolesViewModel = new List<RoleViewModel>();
                ModelState.AddModelError("", $"У роли {roleViewModel.Name} есть привязки к пользователям.");
                throw new Exception($"У роли {roleViewModel.Name} есть привязки к пользователям.");
            }

            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}

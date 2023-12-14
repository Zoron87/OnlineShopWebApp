using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, RoleManager<UserRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> DeleteAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Register registerInfo)
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
                var result = await _userManager.CreateAsync(user, registerInfo.Password); 
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Constants.UserRoleName); 
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", String.Join("\r\n", result.Errors.Select(e => e.Description)));
            }
            return View(registerInfo);
        }

        public async Task<IActionResult> DetailsAsync(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email); 
            return View(user);
        }

        public async Task<IActionResult> EditAsync(string Email)
        {
            var user = (await _userManager.FindByEmailAsync(Email)); 
            var userViewModel = _mapper.Map<UserViewModel>(user);
            ViewBag.Role = new SelectList(_roleManager.Roles.AsEnumerable(), "Name", "Name");
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userViewModel.Id.ToString());
                if (user != null)
                {
                    user.Name = userViewModel.Name;
                    user.Email = userViewModel.Email;

                    if (user.PasswordHash != userViewModel.Password)
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userViewModel.Password);

                    if (user.Role != userViewModel.Role && userViewModel.Role != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, user.Role); 
                        await _userManager.AddToRoleAsync(user, userViewModel.Role); 
                        user.Role = userViewModel.Role;
                    }
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                }
            }
            return View(userViewModel);
        }
    }
}

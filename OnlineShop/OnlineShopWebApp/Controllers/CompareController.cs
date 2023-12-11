using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareStorage _compareStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User>_userManager;

        public CompareController(ICompareStorage compareStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _compareStorage = compareStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            var compareProductsViewModel = (await _compareStorage.TryGetByIdAsync(userId))?.ToCompareViewModel();
            return View(compareProductsViewModel);
        }

        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _compareStorage.AddAsync(userId, productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _compareStorage.ClearAsync(userId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _compareStorage.DeleteAsync(userId, productId);
            return RedirectToAction("Index");
        }
    }
}

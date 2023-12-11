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
    public class CartController : Controller
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;

        public CartController(ICartStorage cartStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _cartStorage = cartStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            var cartViewModel = (await _cartStorage.TryGetByIdAsync(userId))?.ToCartViewModel();
            return View(cartViewModel);
        }

        public async Task<ActionResult> AddAsync(Guid productId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _cartStorage.AddItemAsync(userId, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddItemsAsync(Guid productId, int quantity)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _cartStorage.AddItemAsync(userId, productId, quantity);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ReduceAsync(Guid productId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _cartStorage.ReduceAsync(userId, productId);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteAsync(Guid productId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _cartStorage.DeleteItemAsync(userId, productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _cartStorage.ClearAsync(userId);
            return RedirectToAction("Index");
        }
    }
}
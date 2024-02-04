using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
	{
		private readonly IOrderStorage _orderStorage;
		private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;
		private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, UserViewModel userViewModel, UserManager<User> userManager, IMapper mapper)
        {
            _cartStorage = cartStorage;
            _orderStorage = orderStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
		{
			var orders = await _orderStorage.GetAllAsync();
            return View(orders);
		}

		public async Task<IActionResult> DetailsAsync()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            var cart = await _cartStorage.TryGetByIdAsync(userId);
            if (cart == null) cart = await _cartStorage.CreateAsync(userId);
            var orderDetail = new OrderDetails() { Items = cart.Items, DeliveryDate = DateTime.Now };
            var orderDetailViewModel = _mapper.Map<OrderDetailsViewModel>(orderDetail);
            return View(orderDetailViewModel);
        }

		public IActionResult ThankYou()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(OrderDetailsViewModel orderDetailsViewModel)
		{
			if (orderDetailsViewModel.Name == null || orderDetailsViewModel.Name.Any(c => char.IsDigit(c)))
				ModelState.AddModelError("", "В имени получателя допустимо использовать только буквы");

			if (orderDetailsViewModel.DeliveryDate.AddDays(1) < DateTime.Now)
				ModelState.AddModelError("", "Нельзя выбрать дату доставки ранее текущей");

            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;

            var order = new Order() { UserId = userId };
            var cart = await _cartStorage.TryGetByIdAsync(userId);	

			order.OrderDetails = new OrderDetails() { Items = cart.Items };
            order = _mapper.Map(_mapper.Map<OrderDetails>(orderDetailsViewModel), order);

            if (ModelState.IsValid)
			{
                await _orderStorage.AddAsync(order);
                await _cartStorage.ClearAsync(userId);
                return View("ThankYou");
			}
            return View("Details", _mapper.Map<OrderDetailsViewModel>(order));
        }
    }
}
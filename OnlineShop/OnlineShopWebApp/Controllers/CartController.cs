namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartStorage cartStorage;
		private readonly ICartStorage cartStorage;
		public CartController(ICartStorage cartStorage)
		{
			this.cartStorage = cartStorage;
		}
		cart = cartStorage.TryGetById(ShopUser.Id);
		public ActionResult Index()
		{
			var cart = cartStorage.Get(ShopUser.Id);
			return View(cart);
		}
            return View(cart);
		public ActionResult Add(int productId)
		{
			if (productId > 0)
			{
				cartStorage.AddItem(productId);
				return RedirectToAction("Index");
			}
			return cart != null ? RedirectToAction("Index") : View("Error");
		}

			return View("Error");
		[HttpPost]
		public ActionResult AddItems(int productId, int quantity)
		{
			if (productId > 0)
			{
				cartStorage.AddItem(productId, quantity);
				return RedirectToAction("Index");
			}
			return cart != null ? RedirectToAction("Index") : View("Error");
		}

			return View("Error");
		public IActionResult Delete(int productId)
		{
			if (productId > 0)
				cartStorage.DeleteItem(productId);
			if (cart != null && productId > 0)
				cart = cartStorage.DeleteItem(productId);

			return RedirectToAction("Index");
			public IActionResult Clear()
			{
				cartStorage.Get(ShopUser.Id).Items.Clear();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
			public IActionResult Increase(int productId, int quantity = 1)
			{
				cartStorage.Increase(productId, quantity);
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
			public IActionResult Reduce(int productId, int quantity = 1)
			{
				cartStorage.Reduce(productId, quantity);
				return RedirectToAction("Index");
			}
		}
	}
}
}

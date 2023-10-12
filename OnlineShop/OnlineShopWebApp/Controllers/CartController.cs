namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private Cart cart;
        private readonly ICartStorage cartStorage;

        public CartController(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
            cart = cartStorage.TryGetById(ShopUser.Id);
        }

        public ActionResult Index()
        {
            return View(cart);
        }

        public ActionResult Add(int productId, int quantity = 1)
        {
            if (productId > 0)
            {
                cart = cartStorage.AddItem(productId, quantity);
                return cart != null ? RedirectToAction("Index") : View("Error");
            }

            return View("Error");
        }

        public IActionResult Delete(int productId)
        {
            if (cart != null && productId > 0)
                cart = cartStorage.DeleteItem(productId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cart.Items.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Increase(int productId, int quantity = 1)
        {
            cart = cartStorage.Increase(productId, quantity);
            return RedirectToAction("Index");
        }
        public IActionResult Reduce(int productId, int quantity = 1)
        {
            cart = cartStorage.Reduce(productId, quantity);
            return RedirectToAction("Index");
        }
    }
}

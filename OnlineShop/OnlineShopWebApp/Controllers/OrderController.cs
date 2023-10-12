namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly IOrderStorage orderStorage;
        private readonly ICartStorage cartStorage;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage)
        {
            this.cartStorage = cartStorage;
            this.orderStorage = orderStorage;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderDetails orderDetails)
        {
            var cart = cartStorage.Get(ShopUser.Id);

            if (cart != null || orderDetails != null)
            {
                orderStorage.Save(orderDetails, cart, true);
                cart.Items.Clear();
                return View("ThankYou");
            }
            else
                return View("Error");
        }
    }
}

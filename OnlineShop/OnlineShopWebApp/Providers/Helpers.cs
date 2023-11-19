using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShopWebApp.Providers
{
    public static class Helpers
    {
        public static void CheckNullItem<T>(this T item, string message) where T : class
        {
            if (item == null)
                throw new Exception(message);
        }
    }

    public static class Mapping
    {
        public static List<ProductViewModel> ToProductsViewModel(this List<Product> products)
        {
            var productsViewModel = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = ToProductViewModel(product);
                productsViewModel.Add(productViewModel);
            }
            return productsViewModel;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            var productViewModel = new ProductViewModel();
            productViewModel.Id = product.Id;
            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.Cost = product.Cost;
            productViewModel.ImagePath = product.ImagePath;

            return productViewModel;
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();
            foreach (var item in cart.Items)
            {
                var productViewModel = new ProductViewModel();
                productViewModel.Id = item.Product.Id;
                productViewModel.Name = item.Product.Name;
                productViewModel.Description = item.Product.Description;
                productViewModel.Cost = item.Product.Cost;
                productViewModel.ImagePath = item.Product.ImagePath;
                cartItemsViewModel.Add(new CartItemViewModel(productViewModel, item.Quantity));
            }
            var cartViewModel = new CartViewModel(cart.UserId, cartItemsViewModel);

            return cartViewModel;
        }

        public static Product ItemViewModelToProduct(this Product product, ItemViewModel item)
        {
            product.Name = item.Name;
            product.Description = item.Description;
            product.Cost = item.Cost;
            product.ImagePath = item.ImagePath;

            return product;
        }

        public static FavouriteViewModel ToFavouriteViewModel(this Favourite favourite)
        {
            var productsViewModel = new List<ProductViewModel>();
            foreach (var product in favourite.Products)
            {
                var productViewModel = ToProductViewModel(product);
                productsViewModel.Add(productViewModel);
            }
            var favouriteProductsViewModel = new FavouriteViewModel(favourite.UserId, productsViewModel);

            return favouriteProductsViewModel;
        }

        public static CompareViewModel ToCompareViewModel(this Compare compares)
        {
            var productsViewModel = new List<ProductViewModel>();

            foreach (var product in compares.Products)
            {
                var productViewModel = ToProductViewModel(product);
                productsViewModel.Add(productViewModel);
            }
            var compareViewModel = new CompareViewModel(compares.UserId, productsViewModel);
            return compareViewModel;
        }

        public static List<OrderViewModel> ToOrdersViewModel(this List<Order> orders)
        {
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var orderViewModel = order.ToOrderViewModel();
                ordersViewModel.Add(orderViewModel);
            }
            return ordersViewModel;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            var orderViewModel = new OrderViewModel();
            orderViewModel.Id = order.Id;
            orderViewModel.OrderStatus = (OrderStatusViewModel)order.OrderStatus;
            orderViewModel.CreatedTime = order.CreatedTime;

            orderViewModel.OrderMiddle = new OrderMiddleViewModel();
            orderViewModel.OrderMiddle.Address = order.OrderMiddle.Address;
            orderViewModel.OrderMiddle.Name = order.OrderMiddle.Name;
            orderViewModel.OrderMiddle.Email = order.OrderMiddle.Email;
            orderViewModel.OrderMiddle.Delivery = (DeliveryTypeViewModel?)order.OrderMiddle.Delivery;
            orderViewModel.OrderMiddle.DeliveryDate = order.OrderMiddle.DeliveryDate;
            orderViewModel.OrderMiddle.Pay = (PayTypeViewModel?)order.OrderMiddle.Pay;
            orderViewModel.OrderMiddle.Comment = order.OrderMiddle.Comment;
            orderViewModel.OrderMiddle.Phone = order.OrderMiddle.Phone;

            orderViewModel.OrderMiddle.Items = new List<CartItemViewModel>();
            foreach (var item in order.OrderMiddle.Items)
            {
                var cartItemViewModel = new CartItemViewModel();
                cartItemViewModel.Quantity = item.Quantity;

                cartItemViewModel.Product = new ProductViewModel(); ;
                cartItemViewModel.Product.Id = item.Product.Id;
                cartItemViewModel.Product.Name = item.Product.Name;
                cartItemViewModel.Product.Description = item.Product.Description;
                cartItemViewModel.Product.Cost = item.Product.Cost;
                cartItemViewModel.Product.ImagePath = item.Product.ImagePath;

                orderViewModel.OrderMiddle.Items.Add(cartItemViewModel);
            }
            return orderViewModel;
        }

        public static OrderMiddleViewModel ToOrderViewModel(this OrderMiddle orderMiddle)
        {
            var orderMiddleViewModel = new OrderMiddleViewModel();
            orderMiddleViewModel.Address = orderMiddle.Address;
            orderMiddleViewModel.Name = orderMiddle.Name;
            orderMiddleViewModel.Email = orderMiddle.Email;
            orderMiddleViewModel.Delivery = (DeliveryTypeViewModel?)orderMiddle.Delivery;
            orderMiddleViewModel.DeliveryDate = orderMiddle.DeliveryDate;
            orderMiddleViewModel.Pay = orderMiddleViewModel.Pay;
            orderMiddleViewModel.Comment = orderMiddle.Comment;
            orderMiddleViewModel.Phone = orderMiddle.Phone;

            return orderMiddleViewModel;
        }

        public static OrderMiddleViewModel ToOrderMiddleViewModel(this Order order)
        {
            var orderMiddleViewModel = new OrderMiddleViewModel();
            orderMiddleViewModel.Name = order.OrderMiddle.Name;
            orderMiddleViewModel.Email = order.OrderMiddle.Email;
            orderMiddleViewModel.Address = order.OrderMiddle.Address;
            orderMiddleViewModel.Phone = order.OrderMiddle.Phone;
            orderMiddleViewModel.DeliveryDate = order.OrderMiddle.DeliveryDate;
            orderMiddleViewModel.Delivery = (DeliveryTypeViewModel?)order.OrderMiddle.Delivery;
            orderMiddleViewModel.Pay = (PayTypeViewModel?)order.OrderMiddle.Pay;

            return orderMiddleViewModel;
        }

        public static OrderDetails ToOrderDetails(this OrderDetailsViewModel orderDetailsViewModel)
        {
            var orderDetails = new OrderDetails();
            orderDetails.Name = orderDetailsViewModel.Name;
            orderDetails.Email = orderDetailsViewModel.Email;
            orderDetails.Phone = orderDetailsViewModel.Phone;
            orderDetails.DeliveryDate = orderDetailsViewModel.DeliveryDate;
            orderDetails.Address = orderDetailsViewModel.Address;
            orderDetails.Delivery = (DeliveryType)orderDetailsViewModel.Delivery;
            orderDetails.Comment = orderDetailsViewModel.Comment;

            return orderDetails;
        }
    }

    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}

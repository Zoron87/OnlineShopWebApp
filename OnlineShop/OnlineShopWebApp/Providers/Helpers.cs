using OnlineShop.DB.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
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

            var imagesViewModel = new List<ImageViewModel>();
            foreach (var item in product.ImagesPath)
            {
                var imageViewModel = new ImageViewModel();
                imageViewModel.Id = item.Id;
                imageViewModel.ProductId = item.ProductId;
                imageViewModel.URL = item.URL;

                imagesViewModel.Add(imageViewModel);
            }
            productViewModel.ImagesPath = imagesViewModel;

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

                var imagesViewModel = new List<ImageViewModel>();  
                foreach (var image in item.Product.ImagesPath)
                {
                    var imageViewModel = new ImageViewModel();
                    imageViewModel.Id= image.Id;
                    imageViewModel.ProductId = image.ProductId;
                    imageViewModel.URL = image.URL;

                    imagesViewModel.Add(imageViewModel) ;
                }

                productViewModel.ImagesPath = imagesViewModel;
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

            var images = new List<Image>();
            foreach (var i in item.ImagesPath)
            {
                var image = new Image();
                image.Id = i.Id;
                image.ProductId = i.ProductId;
                image.URL = i.URL;
                images.Add(image);
            }
            product.ImagesPath = images;

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
            if (order != null)
            {
                orderViewModel.Id = order.Id;
                orderViewModel.OrderStatus = (OrderStatusViewModel)order.OrderStatus;
                orderViewModel.CreatedTime = order.CreatedTime;

                orderViewModel.OrderDetails = new OrderDetailsViewModel();
                orderViewModel.OrderDetails.Address = order.OrderDetails.Address;
                orderViewModel.OrderDetails.Name = order.OrderDetails.Name;
                orderViewModel.OrderDetails.Email = order.OrderDetails.Email;
                orderViewModel.OrderDetails.Delivery = (DeliveryTypeViewModel?)order.OrderDetails.Delivery;
                orderViewModel.OrderDetails.DeliveryDate = order.OrderDetails.DeliveryDate;
                orderViewModel.OrderDetails.Pay = (PayTypeViewModel?)order.OrderDetails.Pay;
                orderViewModel.OrderDetails.Comment = order.OrderDetails.Comment;
                orderViewModel.OrderDetails.Phone = order.OrderDetails.Phone;

                orderViewModel.OrderDetails.Items = new List<CartItemViewModel>();
                foreach (var item in order.OrderDetails.Items)
                {
                    var cartItemViewModel = new CartItemViewModel();
                    cartItemViewModel.Quantity = item.Quantity;

                    cartItemViewModel.Product = new ProductViewModel(); ;
                    cartItemViewModel.Product.Id = item.Product.Id;
                    cartItemViewModel.Product.Name = item.Product.Name;
                    cartItemViewModel.Product.Description = item.Product.Description;
                    cartItemViewModel.Product.Cost = item.Product.Cost;
                    
                    var imagesViewModel = new List<ImageViewModel>();
                    foreach (var image in item.Product.ImagesPath)
                    {
                        var imageViewModel = new ImageViewModel();
                        imageViewModel.Id = image.Id;
                        imageViewModel.ProductId = image.ProductId;
                        imageViewModel.URL = image.URL;

                        imagesViewModel.Add(imageViewModel);
                    }
                    cartItemViewModel.Product.ImagesPath = imagesViewModel;
                    orderViewModel.OrderDetails.Items.Add(cartItemViewModel);
                }
            }
                return orderViewModel;
        }

        public static OrderDetailsViewModel ToOrderViewModel(this OrderDetails orderDetails)
        {
            var orderDetailViewModel = new OrderDetailsViewModel();
            orderDetailViewModel.Address = orderDetails.Address;
            orderDetailViewModel.Name = orderDetails.Name;
            orderDetailViewModel.Email = orderDetails.Email;
            orderDetailViewModel.Delivery = (DeliveryTypeViewModel?)orderDetails.Delivery;
            orderDetailViewModel.DeliveryDate = orderDetails.DeliveryDate;
            orderDetailViewModel.Pay = (PayTypeViewModel?)orderDetails.Pay;
            orderDetailViewModel.Comment = orderDetails.Comment;
            orderDetailViewModel.Phone = orderDetails.Phone;

            return orderDetailViewModel;
        }

        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order)
        {
            var orderDetailViewModel = new OrderDetailsViewModel();
            orderDetailViewModel.Name = order.OrderDetails.Name;
            orderDetailViewModel.Email = order.OrderDetails.Email;
            orderDetailViewModel.Address = order.OrderDetails.Address;
            orderDetailViewModel.Phone = order.OrderDetails.Phone;
            orderDetailViewModel.DeliveryDate = order.OrderDetails.DeliveryDate;
            orderDetailViewModel.Delivery = (DeliveryTypeViewModel?)order.OrderDetails.Delivery;
            orderDetailViewModel.Pay = (PayTypeViewModel?)order.OrderDetails.Pay;

            return orderDetailViewModel;
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

        public static List<RoleViewModel> ToRoleViewModel(this List<UserRole> roles)
        {
            var rolesViewModel = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                var roleViewModel = new RoleViewModel();
                roleViewModel.Name = role.Name;
                roleViewModel.Description = role.Description;

                rolesViewModel.Add(roleViewModel);
            }
            return rolesViewModel;
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            var userViewModel = new UserViewModel();
            userViewModel.Id = Guid.Parse(user.Id);
            userViewModel.Name = user.UserName;
            userViewModel.Email = user.Email;
            userViewModel.Password = user.PasswordHash;
            userViewModel.Role = user.Role;

            return userViewModel;
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

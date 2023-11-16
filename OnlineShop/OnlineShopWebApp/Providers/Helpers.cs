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
    }

    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}

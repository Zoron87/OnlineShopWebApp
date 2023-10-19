using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Providers
{
    public static class Helpers<T>
    {
        public static void CheckNullItem (T cartItem)
        {
            if (cartItem == null)
                throw new Exception("Указанный товар не обнаружен!");
        }
    }
}

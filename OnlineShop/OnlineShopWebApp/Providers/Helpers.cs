using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Providers
{
    public static class Helpers<T>
    {
        public static void CheckNullItem (T item, string message)
        {
            if (item == null)
                throw new Exception(message);
        }
    }
}

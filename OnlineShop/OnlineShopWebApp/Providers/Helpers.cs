using System;
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

    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}

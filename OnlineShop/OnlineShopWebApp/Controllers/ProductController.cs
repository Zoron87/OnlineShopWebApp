using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class ProductController : Controller
	{
        private ProductRepository productRepository = new ProductRepository();
        public string Index(int id)
		{
			var currentProduct = productRepository.TryGetById(id);
			return (currentProduct != null) ? currentProduct.ToString() : $"Продукт с id {id} не найден";
		}
	}
}

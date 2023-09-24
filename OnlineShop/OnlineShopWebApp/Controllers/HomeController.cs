using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
	{
        private ProductRepository productRepository = new ProductRepository();
        public string Index()
		{
			var products = productRepository.GetAll();
			return String.Join("\n", products);
		}
	}
}

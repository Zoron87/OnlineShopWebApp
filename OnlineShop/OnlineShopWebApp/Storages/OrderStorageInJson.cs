using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Storages
{
	public class OrderStorageInJson : IOrderStorage
	{
		private readonly string filePath = "Storages/Orders.txt";

		private List<Order> orders;

		public OrderStorageInJson()
		{
			orders = new List<Order>();
		}

		public void Add(Order order)
		{
			orders = GetAll();

			orders.Add(order);

			SaveAll(orders);
		}

		public void SaveAll(List<Order> orders)
		{
			FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(orders, Formatting.Indented), false);
		}

		public List<Order> GetAll()
		{
			var oldOrders = FileProvider.GetInfo(filePath);
			if (!String.IsNullOrEmpty(oldOrders))
				return JsonConvert.DeserializeObject<List<Order>>(oldOrders);

			return orders;
		}
	}
}

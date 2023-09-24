using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Ноутбук игровой MSI Katana 17 B12VEK-482XRU", 99999, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг. "),
            new Product("Телевизор Samsung QE43Q60BAU", 39999, "Телевизор Samsung QE43Q60BAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки."),
            new Product("Холодильник Midea MDRB499FGF01IM", 39999, "Холодильник Midea MDRB499FGF01IM, белый оснащен холодильной камерой объемом 250 л и нижней морозильной камерой объемом 76 л. ")
        };

        public List<Product> GetAll()
        {
            return products;
        }
    }
}

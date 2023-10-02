using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public class ProductStorageInit
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Ноутбук игровой MSI Katana 17 B12VEK-482XRU", 99999, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.", "notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg"),
            new Product("Телевизор Samsung QE43Q60BAU", 39999, "Телевизор Samsung QE43Q60BAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки.", "tv_Samsung_QE43Q60BAU_1.jpg"),
            new Product("Холодильник Midea MDRB499FGF01IM", 39999, "Холодильник Midea MDRB499FGF01IM, белый оснащен холодильной камерой объемом 250 л и нижней морозильной камерой объемом 76 л.", "Refrigerator_Midea_MDRB499FGF01IM_1.jpg"),
            new Product("Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White", 18999, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 160 м² площади без подзарядки", "Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg"),
            new Product("Электрический духовой шкаф Gorenje BO6737E02X", 29999, "Gorenje BO6737E02X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.", "Electric_oven_Gorenje_BO6737E02X_1.jpg")
        };

        public List<Product> GetAll()
        {
            return products;
        }
    }
}

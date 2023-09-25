using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Repositories
{
    public class ProductStorageInit
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Ноутбук игровой MSI Katana 17 B12VEK-482XRU", 99999, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг."),
            new Product("Телевизор Samsung QE43Q60BAU", 39999, "Телевизор Samsung QE43Q60BAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки."),
            new Product("Холодильник Midea MDRB499FGF01IM", 39999, "Холодильник Midea MDRB499FGF01IM, белый оснащен холодильной камерой объемом 250 л и нижней морозильной камерой объемом 76 л."),
            new Product("Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White", 18999, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 160 м² площади без подзарядки"),
            new Product("Электрический духовой шкаф Gorenje BO6737E02X", 29999, "Gorenje BO6737E02X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты."),
            new Product("Сплит-система Haier HSU-07HRM103/R3", 25999, "Сплит-система Haier HSU-07HRM103/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до 20 м². В комплект входит пульт дистанционного управления с дисплеем."),
            new Product("Морозильная камера Haier HF-82WAA", 19999, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки."),
            new Product("Холодильник Midea MDRB499FGF01IM", 21999, "Планшет Honor Pad X9 Wi-Fi Space Gray 5301AGJC функционирует на базе предустановленной ОС MagicOS 7.1.")
        };

        public List<Product> GetAll()
        {
            return products;
        }
    }
}

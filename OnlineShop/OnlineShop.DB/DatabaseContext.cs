using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate(); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(u => u.OrderDetails).WithOne().HasForeignKey<OrderDetails>(x => x.Id);

            var product1Id = Guid.Parse("168defec-16fe-4dec-8db1-8d968036bd89");

            var image1 = new Image()
            {
                Id = Guid.Parse("2f33830e-c282-406c-9484-131dc36caa5c"),
                URL = "/img/products/notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg",
                ProductId = product1Id
            };

            var image2 = new Image()
            {
                Id = Guid.Parse("d1f639d8-ee07-4a1c-92a6-37b9b85f261d"),
                URL = "/img/products/notebook_MSI_Katana_17_B12VEK-482XRU_2.jpg",
                ProductId = product1Id
            };

            modelBuilder.Entity<Image>().HasData(image2, image1);

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = product1Id,
                   Name = "Ноутбук игровой MSI Katana 17 B12VEK-482XRU",
                   Cost = 99999,
                   Description = "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.",
               }
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Телевизор Samsung QE43QBAU1",
               //    Cost = 69999,
               //    Description = "Телевизор Samsung QE43QBAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки. ",
               //    ImagePath = "tv_Samsung_QE43QBAU_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Холодильник Midea MDRB499FG1IM",
               //    Cost = 79999,
               //    Description = "Холодильник Midea MDRB499FG1IM, белый оснащен холодильной камерой объемом 2 л и нижней морозильной камерой объемом 76 л.",
               //    ImagePath = "Refrigerator_Midea_MDRB499FG1IM_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White",
               //    Cost = 18999,
               //    Description = "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки",
               //    ImagePath = "Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Электрический духовой шкаф Gorenje BO67372X",
               //    Cost = 29999,
               //    Description = "Gorenje BO67372X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.",
               //    ImagePath = "Electric_oven_Gorenje_BO67372X_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Сплит-система Haier HSU7HRM3/R3",
               //    Cost = 25999,
               //    Description = "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.",
               //    ImagePath = "Air_conditioner_Haier_HSU7HRM3_1.jpg" 
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Морозильная камера Haier HF-82WAA",
               //    Cost = 19999,
               //    Description = "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.",
               //    ImagePath = "Freezer_Haier_HF-82WAA_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Холодильник Midea MDRB499FG1IM",
               //    Cost = 21999,
               //    Description = "Холодильник Midea MDRB499FG1IM",
               //    ImagePath = "Refrigerator_Midea_MDRB499FG1IM_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Встраиваемая электрическая панель Gorenje ECT641BX",
               //    Cost = 999,
               //    Description = "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.",
               //    ImagePath = "Built-in_electric_panel_Gorenje_ECT641BX_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Консоль Sony PlayStation 5 Blu-Ray Edition CFI-120/16/18)A",
               //    Cost = 999,
               //    Description = "Консоль PlayStation 5 CFI-120/16/18)A оборудована внутренним хранилищем данных емкостью 825 Гб. Этот вид консоли поддерживает воспроизводство формата Blu-Ray и технологию HDR.",
               //    ImagePath = "Sony_PlayStation_5_Blu-ray_Edition_Console_CFI-12_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Смартфон HONOR X9a 6/128GB 59ALXQ Black",
               //    Cost = 24999,
               //    Description = "Смартфон Honor X9A 59ALXQ, черный — модель среднего класса с экраном диагональю 6,67 дюймов и премиальным дизайном.",
               //    ImagePath = "HONOR X9a_6_128GB_5109ALXQ_Black_smartphone_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Стиральная машина узкая Beko WSPE7612W",
               //    Cost = 27999,
               //    Description = "Beko WSPE7612W – узкая стиральная машина, которая точно поместится в вашей ванной комнате.",
               //    ImagePath = "Beko_WSPE7612W_narrow_washing_machine_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Холодильник (Side-by-Side) Haier HRF-541DG7RU",
               //    Cost = 93999,
               //    Description = "Холодильник Haier HRF-541DG7RU — это устройство Side-by-Side с множеством функций, которые помогут в повседневной жизни.",
               //    ImagePath = "Refrigerator_(Side-by-Side)_Haier_HRF-541DG7RU_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Смартфон Nothing Phone 12/256GB Dark Gray (65)",
               //    Cost = 78999,
               //    Description = "Смартфон Nothing Phone 2 Dark Gray (65) — 6,55-дюймовый экран с матрицей OLED, поддерживающий разрешение 2412х пикселей.",
               //    ImagePath = "Nothing_Phone_12_256GB_Dark_Gray_(65)_Smartphone_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S",
               //    Cost = 658999,
               //    Description = "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S представлен в корпусе черного цвета.",
               //    ImagePath = "Refrigerator_Kuppersbusch_FKG_98_S_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Ноутбук игровой MSI Raider GE78 HX 13VH-5RU (MS-17S1)",
               //    Cost = 314999,
               //    Description = "Игровой ноутбук MSI Raider GE78 HX 13VH-5RU (MS-17S1) — модель в пластиковом корпусе черного цвета, которая поставляется с предустановленной ОС Windows 11 «Домашняя».",
               //    ImagePath = "MSI_Raider_GE78_HX_13VH-205RU_Gaming_Notebook_(MS-17S1)_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Компактный духовой шкаф Премиум Kuppersbusch CBP 65 W2 Black Chrome",
               //    Cost = 311199,
               //    Description = "Компактный духовой шкаф Kuppersbusch CBP 65 стильно выглядит и предоставляет широкие возможности для приготовления повседневной еды и угощения на праздничный стол.",
               //    ImagePath = "Kuppersbusch_CBP_6550.0_W2_Black_Chrome_Premium_Compact_Oven_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Ноутбук игровой Thunderobot 911 M G2 Pro 7 J090DRU",
               //    Cost = 129999,
               //    Description = "Игровой ноутбук Thunderobot 911 M G2 Pro 7 представлен в пластиковом корпусе серого цвета — модель с предустановленной ОС Windows 11, время автономной работы которой достигает 4,5 часов.",
               //    ImagePath = "Thunderobot_911_M_G2_Pro_7_gaming_laptop_J090DRU_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Телевизор LG OLED83C3RLA",
               //    Cost = 679999,
               //    Description = "Телевизор LG OLED83C3RLA отличается диагональю экрана 83. Разрешение экрана — 4К. Устройство выполнено на базе технологии Dolby Vision, благодаря чему картинка будет всегда оставаться яркой, контрастной и насыщенной",
               //    ImagePath = "LG_OLED83C3RLA_TV_set_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Смартфон Xiaomi Redmi Note 12S 256GB Onyx Black",
               //    Cost = 999,
               //    Description = "Смартфон Xiaomi Redmi Note 12S Onyx Black оснащен дисплеем диагональю 6,43 дюйма, выполненным по технологии AMOLED.",
               //    ImagePath = "Xiaomi_Redmi_Note_12S_256GB_Onyx_Black_smartphone_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Смартфон Samsung Galaxy Z Fold5 512GB Phantom Black (SM-F946B)",
               //    Cost = 199999,
               //    Description = "Складной смартфон Samsung Galaxy Z Fold5 Phantom Black (SM-F946B) оснащен 7,6-дюймовым экраном разрешением 2176x1812 пикселей, обладающим пиковой яркостью 17 нит, что позволит смотреть кино или играть даже под солнечными лучами — изображение не поблекнет.",
               //    ImagePath = "Samsung_Galaxy_Z_Fold5_512GB_Phantom_Black_Smartphone_(SM-F946B)_1.jpg"
               //},
               //new Product()
               //{
               //    Id = Guid.NewGuid(),
               //    Name = "Телевизор TCL 55C745",
               //    Cost = 74999,
               //    Description = "Телевизор TCL 55C745 обладает габаритами 77х122х32 см. Вес устройства — 15 кг, без подставки — 13,5 кг.",
               //    ImagePath = "TV_TCL_55C745_1.jpg"
               //}
               ) ;
        }
    }
}

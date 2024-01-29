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

            // product1
            var product1Id = Guid.Parse("168defec-16fe-4dec-8db1-8d968036bd89");
            var image1Product1 = new Image()
            {
                Id = Guid.Parse("2f33830e-c282-406c-9484-131dc36caa5c"),
                URL = "/img/products/notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg",
                ProductId = product1Id
            };
            var image2Product1 = new Image()
            {
                Id = Guid.Parse("d1f639d8-ee07-4a1c-92a6-37b9b85f261d"),
                URL = "/img/products/notebook_MSI_Katana_17_B12VEK-482XRU_2.jpg",
                ProductId = product1Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product1, image2Product1);

            // product2
            var product2Id = Guid.Parse("06fe75f0-09f2-4489-8d11-42f6c816baef");
            var image1Product2 = new Image()
            {
                Id = Guid.Parse("cec15667-ebba-40a6-8f00-6b82825ae2df"),
                URL = "/img/products/tv_Samsung_QE43Q60BAU_1.jpg",
                ProductId = product2Id
            };
            var image2Product2 = new Image()
            {
                Id = Guid.Parse("d8052407-64bc-4543-b1ba-7da5fac09516"),
                URL = "/img/products/tv_Samsung_QE43Q60BAU_2.jpg",
                ProductId = product2Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product2, image2Product2);

            // product3
            var product3Id = Guid.Parse("d3765151-d68f-41ea-a8b9-27bae6f2b8a0");
            var image1Product3 = new Image()
            {
                Id = Guid.Parse("34712b35-335b-4863-a109-0bfb0c612938"),
                URL = "/img/products/Refrigerator_Midea_MDRB499FGF01IM_1.jpg",
                ProductId = product3Id
            };
            var image2Product3 = new Image()
            {
                Id = Guid.Parse("c841fc87-3d4c-47be-ae15-fce88542d3c3"),
                URL = "/img/products/Refrigerator_Midea_MDRB499FGF01IM_2.jpg",
                ProductId = product3Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product3, image2Product3);

            // product4
            var product4Id = Guid.Parse("1f06e50b-989b-4827-89db-4859d1d49998");
            var image1Product4 = new Image()
            {
                Id = Guid.Parse("e469883a-82d5-4b1e-9538-fe6d05dd1360"),
                URL = "/img/products/Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg",
                ProductId = product4Id
            };
            var image2Product4 = new Image()
            {
                Id = Guid.Parse("683efc32-0514-44a8-bda8-eb3ea45e3f42"),
                URL = "/img/products/Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_2.jpg",
                ProductId = product4Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product4, image2Product4);

            // product5
            var product5Id = Guid.Parse("2c9d0079-8bdd-43bb-beba-bcde5a43d6c7");
            var image1Product5 = new Image()
            {
                Id = Guid.Parse("91db92bb-3e37-4219-9fcc-62b3d670a15c"),
                URL = "/img/products/Electric_oven_Gorenje_BO6737E02X_1.jpg",
                ProductId = product5Id
            };
            var image2Product5 = new Image()
            {
                Id = Guid.Parse("b2681e3d-da09-41e5-8df0-9867bc47e4f2"),
                URL = "/img/products/Electric_oven_Gorenje_BO6737E02X_2.jpg",
                ProductId = product5Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product5, image2Product5);

            // product6
            var product6Id = Guid.Parse("6f74b568-cf38-4caa-92c3-dbc45437a2aa");
            var image1Product6 = new Image()
            {
                Id = Guid.Parse("cf1b1834-bdb7-4fbe-82a2-4dd06d635640"),
                URL = "/img/products/Air_conditioner_Haier_HSU7HRM3_1.jpg",
                ProductId = product6Id
            };
            var image2Product6 = new Image()
            {
                Id = Guid.Parse("67dea053-c686-41a5-9e37-bf33ae82bada"),
                URL = "/img/products/Air_conditioner_Haier_HSU7HRM3_2.jpg",
                ProductId = product6Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product6, image2Product6);

            // product7
            var product7Id = Guid.Parse("2842320a-f42d-4f81-880f-488778526f5d");
            var image1Product7 = new Image()
            {
                Id = Guid.Parse("b6596218-042a-48b7-a62e-38ce8ed7ddd0"),
                URL = "/img/products/Freezer_Haier_HF-82WAA_1.jpg",
                ProductId = product7Id
            };
            var image2Product7 = new Image()
            {
                Id = Guid.Parse("a9ccb1f9-56e1-46f5-80f2-5391b9422750"),
                URL = "/img/products/Freezer_Haier_HF-82WAA_2.jpg",
                ProductId = product7Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product7, image2Product7);

            // product8
            var product8Id = Guid.Parse("7f15a38b-fcb6-4241-87e8-8148e148e5b4");
            var image1Product8 = new Image()
            {
                Id = Guid.Parse("f5de0b00-1a25-4602-923d-661df4acc2f7"),
                URL = "/img/products/Built-in_electric_panel_Gorenje_ECT641BX_1.jpg",
                ProductId = product8Id
            };
            var image2Product8 = new Image()
            {
                Id = Guid.Parse("b5c66945-d510-49d7-811d-0383d46fdab8"),
                URL = "/img/products/Built-in_electric_panel_Gorenje_ECT641BX_2.jpg",
                ProductId = product8Id
            };
            modelBuilder.Entity<Image>().HasData(image1Product8, image2Product8);


            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = product1Id,
                   Name = "Ноутбук игровой MSI Katana 17 B12VEK-482XRU",
                   Cost = 99999,
                   Description = "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.",
               },
               new Product()
               {
                   Id = product2Id,
                   Name = "Телевизор Samsung QE43QBAU1",
                   Cost = 69999,
                   Description = "Телевизор Samsung QE43QBAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки. ",
               },
               new Product()
               {
                   Id = product3Id,
                   Name = "Холодильник Midea MDRB499FG1IM",
                   Cost = 79999,
                   Description = "Холодильник Midea MDRB499FG1IM, белый оснащен холодильной камерой объемом 2 л и нижней морозильной камерой объемом 76 л.",
               },
               new Product()
               {
                   Id = product4Id,
                   Name = "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White",
                   Cost = 18999,
                   Description = "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки",
               },
               new Product()
               {
                   Id = product5Id,
                   Name = "Электрический духовой шкаф Gorenje BO67372X",
                   Cost = 29999,
                   Description = "Gorenje BO67372X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.",
               },
               new Product()
               {
                   Id = product6Id,
                   Name = "Сплит-система Haier HSU7HRM3/R3",
                   Cost = 25999,
                   Description = "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.",
               },
               new Product()
               {
                   Id = product7Id,
                   Name = "Морозильная камера Haier HF-82WAA",
                   Cost = 19999,
                   Description = "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.",
               },
               new Product()
               {
                   Id = product8Id,
                   Name = "Встраиваемая электрическая панель Gorenje ECT641BX",
                   Cost = 9999,
                   Description = "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.",
               }
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
               );
        }
    }
}

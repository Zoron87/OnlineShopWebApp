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
            new Product("Электрический духовой шкаф Gorenje BO6737E02X", 29999, "Gorenje BO6737E02X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.", "Electric_oven_Gorenje_BO6737E02X_1.jpg"),
            new Product("Сплит-система Haier HSU-07HRM103/R3", 25999, "Сплит-система Haier HSU-07HRM103/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до 20 м². В комплект входит пульт дистанционного управления с дисплеем.", "Air_conditioner_Haier_HSU-07HRM103_1.jpg"),
            new Product("Морозильная камера Haier HF-82WAA", 19999, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.", "Freezer_Haier_HF-82WAA_1.jpg"),
            new Product("Холодильник Midea MDRB499FGF01IM", 21999, "Планшет Honor Pad X9 Wi-Fi Space Gray 5301AGJC функционирует на базе предустановленной ОС MagicOS 7.1.", "Refrigerator_Midea_MDRB499FGF01IM_1.jpg"),
            new Product("Встраиваемая электрическая панель Gorenje ECT641BX", 20999, "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.", "Built-in_electric_panel_Gorenje_ECT641BX_1.jpg"),
            new Product("Консоль Sony PlayStation 5 Blu-Ray Edition CFI-12(00/16/18)A", 60999, "Консоль PlayStation 5 CFI-12(00/16/18)A оборудована внутренним хранилищем данных емкостью 825 Гб. Этот вид консоли поддерживает воспроизводство формата Blu-Ray и технологию HDR.", "Sony_PlayStation_5_Blu-ray_Edition_Console_CFI-12_1.jpg"),
            new Product("Смартфон HONOR X9a 6/128GB 5109ALXQ Black", 24999, "Смартфон Honor X9A 5109ALXQ, черный — модель среднего класса с экраном диагональю 6,67 дюймов и премиальным дизайном.", "HONOR X9a_6_128GB_5109ALXQ_Black_smartphone_1.jpg"),
            new Product("Стиральная машина узкая Beko WSPE7612W", 27999, "Beko WSPE7612W – узкая стиральная машина, которая точно поместится в вашей ванной комнате.", "Beko_WSPE7612W_narrow_washing_machine_1.jpg"),
            new Product("Холодильник (Side-by-Side) Haier HRF-541DG7RU", 93999, "Холодильник Haier HRF-541DG7RU — это устройство Side-by-Side с множеством функций, которые помогут в повседневной жизни.", "Refrigerator_(Side-by-Side)_Haier_HRF-541DG7RU_1.jpg"),
            new Product("Смартфон Nothing Phone 12/256GB Dark Gray (A065)", 78999, "Смартфон Nothing Phone 2 Dark Gray (A065) — 6,55-дюймовый экран с матрицей OLED, поддерживающий разрешение 2412х1080 пикселей.", "Nothing_Phone_12_256GB_Dark_Gray_(A065)_Smartphone_1.jpg"),
            new Product("Холодильник с нижней морозильной камерой Kuppersbusch FKG 9860.0 S", 658999, "Холодильник с нижней морозильной камерой Kuppersbusch FKG 9860.0 S представлен в корпусе черного цвета.", "Refrigerator_Kuppersbusch_FKG_9860.0_S_1.jpg"),
            new Product("Ноутбук игровой MSI Raider GE78 HX 13VH-205RU (MS-17S1)", 314999, "Игровой ноутбук MSI Raider GE78 HX 13VH-205RU (MS-17S1) — модель в пластиковом корпусе черного цвета, которая поставляется с предустановленной ОС Windows 11 «Домашняя».", "MSI_Raider_GE78_HX_13VH-205RU_Gaming_Notebook_(MS-17S1)_1.jpg"),
            new Product("Компактный духовой шкаф Премиум Kuppersbusch CBP 6550.0 W2 Black Chrome", 311199, "Компактный духовой шкаф Kuppersbusch CBP 6550.0 стильно выглядит и предоставляет широкие возможности для приготовления повседневной еды и угощения на праздничный стол.", "Kuppersbusch_CBP_6550.0_W2_Black_Chrome_Premium_Compact_Oven_1.jpg"),
            new Product("Ноутбук игровой Thunderobot 911 M G2 Pro 7 JT009U00DRU", 129999, "Игровой ноутбук Thunderobot 911 M G2 Pro 7 представлен в пластиковом корпусе серого цвета — модель с предустановленной ОС Windows 11, время автономной работы которой достигает 4,5 часов.", "Thunderobot_911_M_G2_Pro_7_gaming_laptop_JT009U00DRU_1.jpg"),
            new Product("Телевизор LG OLED83C3RLA", 679999,"Телевизор LG OLED83C3RLA отличается диагональю экрана 83. Разрешение экрана — 4К. Устройство выполнено на базе технологии Dolby Vision, благодаря чему картинка будет всегда оставаться яркой, контрастной и насыщенной", "LG_OLED83C3RLA_TV_set_1.jpg"),
            new Product("Смартфон Xiaomi Redmi Note 12S 256GB Onyx Black", 20999, "Смартфон Xiaomi Redmi Note 12S Onyx Black оснащен дисплеем диагональю 6,43 дюйма, выполненным по технологии AMOLED.", "Xiaomi_Redmi_Note_12S_256GB_Onyx_Black_smartphone_1.jpg"),
            new Product("Смартфон Samsung Galaxy Z Fold5 512GB Phantom Black (SM-F946B)", 199999, "Складной смартфон Samsung Galaxy Z Fold5 Phantom Black (SM-F946B) оснащен 7,6-дюймовым экраном разрешением 2176x1812 пикселей, обладающим пиковой яркостью 1750 нит, что позволит смотреть кино или играть даже под солнечными лучами — изображение не поблекнет.", "Samsung_Galaxy_Z_Fold5_512GB_Phantom_Black_Smartphone_(SM-F946B)_1.jpg"),
            new Product("Телевизор TCL 55C745", 74999, "Телевизор TCL 55C745 обладает габаритами 77х122х32 см. Вес устройства — 15 кг, без подставки — 13,5 кг.", "TV_TCL_55C745_1.jpg")
        };

        public List<Product> GetAll()
        {
            return products;
        }
    }
}

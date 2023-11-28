using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DB.Migrations
{
    public partial class InitProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompareId = table.Column<int>(type: "int", nullable: true),
                    FavouriteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Compares_CompareId",
                        column: x => x.CompareId,
                        principalTable: "Compares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Favourites_FavouriteId",
                        column: x => x.FavouriteId,
                        principalTable: "Favourites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pay = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompareId", "Cost", "Description", "FavouriteId", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("e361e636-ed2c-4a05-9bf1-9b3f2a74949d"), null, 99999m, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.", null, "notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg", "Ноутбук игровой MSI Katana 17 B12VEK-482XRU" },
                    { new Guid("d5063618-3c3d-417a-a96d-4c905866a720"), null, 999m, "Смартфон Xiaomi Redmi Note 12S Onyx Black оснащен дисплеем диагональю 6,43 дюйма, выполненным по технологии AMOLED.", null, "Xiaomi_Redmi_Note_12S_256GB_Onyx_Black_smartphone_1.jpg", "Смартфон Xiaomi Redmi Note 12S 256GB Onyx Black" },
                    { new Guid("586d7536-022c-4d93-9fcb-49a8cf402995"), null, 679999m, "Телевизор LG OLED83C3RLA отличается диагональю экрана 83. Разрешение экрана — 4К. Устройство выполнено на базе технологии Dolby Vision, благодаря чему картинка будет всегда оставаться яркой, контрастной и насыщенной", null, "LG_OLED83C3RLA_TV_set_1.jpg", "Телевизор LG OLED83C3RLA" },
                    { new Guid("1f14d4ed-719e-42c0-97df-bbfc5f330f10"), null, 129999m, "Игровой ноутбук Thunderobot 911 M G2 Pro 7 представлен в пластиковом корпусе серого цвета — модель с предустановленной ОС Windows 11, время автономной работы которой достигает 4,5 часов.", null, "Thunderobot_911_M_G2_Pro_7_gaming_laptop_J090DRU_1.jpg", "Ноутбук игровой Thunderobot 911 M G2 Pro 7 J090DRU" },
                    { new Guid("d1061ae1-c6ad-498d-b43e-7984c89bc841"), null, 311199m, "Компактный духовой шкаф Kuppersbusch CBP 65 стильно выглядит и предоставляет широкие возможности для приготовления повседневной еды и угощения на праздничный стол.", null, "Kuppersbusch_CBP_6550.0_W2_Black_Chrome_Premium_Compact_Oven_1.jpg", "Компактный духовой шкаф Премиум Kuppersbusch CBP 65 W2 Black Chrome" },
                    { new Guid("8eb49757-d94e-4eb3-bdb7-c7d9ab1850e3"), null, 314999m, "Игровой ноутбук MSI Raider GE78 HX 13VH-5RU (MS-17S1) — модель в пластиковом корпусе черного цвета, которая поставляется с предустановленной ОС Windows 11 «Домашняя».", null, "MSI_Raider_GE78_HX_13VH-205RU_Gaming_Notebook_(MS-17S1)_1.jpg", "Ноутбук игровой MSI Raider GE78 HX 13VH-5RU (MS-17S1)" },
                    { new Guid("b2883b53-7cc8-4fc8-aacc-3dfc02fff313"), null, 658999m, "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S представлен в корпусе черного цвета.", null, "Refrigerator_Kuppersbusch_FKG_98_S_1.jpg", "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S" },
                    { new Guid("add6e1f2-c994-4549-90c3-30c0818ace8b"), null, 78999m, "Смартфон Nothing Phone 2 Dark Gray (65) — 6,55-дюймовый экран с матрицей OLED, поддерживающий разрешение 2412х пикселей.", null, "Nothing_Phone_12_256GB_Dark_Gray_(65)_Smartphone_1.jpg", "Смартфон Nothing Phone 12/256GB Dark Gray (65)" },
                    { new Guid("dff774df-d8de-4a34-8c59-ff3db38c7540"), null, 93999m, "Холодильник Haier HRF-541DG7RU — это устройство Side-by-Side с множеством функций, которые помогут в повседневной жизни.", null, "Refrigerator_(Side-by-Side)_Haier_HRF-541DG7RU_1.jpg", "Холодильник (Side-by-Side) Haier HRF-541DG7RU" },
                    { new Guid("9d2f5725-a856-4728-bae1-827edf6cfabd"), null, 27999m, "Beko WSPE7612W – узкая стиральная машина, которая точно поместится в вашей ванной комнате.", null, "Beko_WSPE7612W_narrow_washing_machine_1.jpg", "Стиральная машина узкая Beko WSPE7612W" },
                    { new Guid("f994ad2a-ef8a-4590-8eef-e183371878ef"), null, 24999m, "Смартфон Honor X9A 59ALXQ, черный — модель среднего класса с экраном диагональю 6,67 дюймов и премиальным дизайном.", null, "HONOR X9a_6_128GB_5109ALXQ_Black_smartphone_1.jpg", "Смартфон HONOR X9a 6/128GB 59ALXQ Black" },
                    { new Guid("9ba34ed7-4266-45d0-a1ef-a671605066d4"), null, 999m, "Консоль PlayStation 5 CFI-120/16/18)A оборудована внутренним хранилищем данных емкостью 825 Гб. Этот вид консоли поддерживает воспроизводство формата Blu-Ray и технологию HDR.", null, "Sony_PlayStation_5_Blu-ray_Edition_Console_CFI-12_1.jpg", "Консоль Sony PlayStation 5 Blu-Ray Edition CFI-120/16/18)A" },
                    { new Guid("40a06d09-4d14-439b-afa7-cc318307e154"), null, 999m, "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.", null, "Built-in_electric_panel_Gorenje_ECT641BX_1.jpg", "Встраиваемая электрическая панель Gorenje ECT641BX" },
                    { new Guid("fece736d-4578-4c60-8a53-fc1b703b70c0"), null, 21999m, "Холодильник Midea MDRB499FG1IM", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("459ae4dc-bd67-4048-8400-778d9fc37c3b"), null, 19999m, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.", null, "Freezer_Haier_HF-82WAA_1.jpg", "Морозильная камера Haier HF-82WAA" },
                    { new Guid("e8404908-98d1-4117-978c-07de8efeeb81"), null, 25999m, "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.", null, "Air_conditioner_Haier_HSU7HRM3_1.jpg", "Сплит-система Haier HSU7HRM3/R3" },
                    { new Guid("8d6915a2-9be8-4830-9fee-cbf3b1060816"), null, 29999m, "Gorenje BO67372X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.", null, "Electric_oven_Gorenje_BO67372X_1.jpg", "Электрический духовой шкаф Gorenje BO67372X" },
                    { new Guid("67f68d6c-c53d-44ce-9074-590896faa1d6"), null, 18999m, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки", null, "Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg", "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White" },
                    { new Guid("95f528da-af04-4528-8938-d46da4c33783"), null, 79999m, "Холодильник Midea MDRB499FG1IM, белый оснащен холодильной камерой объемом 2 л и нижней морозильной камерой объемом 76 л.", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("5fdd13e1-f997-4149-83c3-8df1350aaae7"), null, 69999m, "Телевизор Samsung QE43QBAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки. ", null, "tv_Samsung_QE43QBAU_1.jpg", "Телевизор Samsung QE43QBAU1" },
                    { new Guid("0c7bb370-1f02-47d1-9e35-0e7b54ae5e34"), null, 199999m, "Складной смартфон Samsung Galaxy Z Fold5 Phantom Black (SM-F946B) оснащен 7,6-дюймовым экраном разрешением 2176x1812 пикселей, обладающим пиковой яркостью 17 нит, что позволит смотреть кино или играть даже под солнечными лучами — изображение не поблекнет.", null, "Samsung_Galaxy_Z_Fold5_512GB_Phantom_Black_Smartphone_(SM-F946B)_1.jpg", "Смартфон Samsung Galaxy Z Fold5 512GB Phantom Black (SM-F946B)" },
                    { new Guid("d9d352f6-a13a-4f25-a1c3-a49683aa5875"), null, 74999m, "Телевизор TCL 55C745 обладает габаритами 77х122х32 см. Вес устройства — 15 кг, без подставки — 13,5 кг.", null, "TV_TCL_55C745_1.jpg", "Телевизор TCL 55C745" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_OrderDetailsId",
                table: "CartItem",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompareId",
                table: "Products",
                column: "CompareId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavouriteId",
                table: "Products",
                column: "FavouriteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Compares");

            migrationBuilder.DropTable(
                name: "Favourites");
        }
    }
}

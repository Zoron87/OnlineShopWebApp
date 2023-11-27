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
                    { new Guid("9057a7f0-1442-486d-aa70-c669fc6de6f8"), null, 99999m, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.", null, "notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg", "Ноутбук игровой MSI Katana 17 B12VEK-482XRU" },
                    { new Guid("9709fd35-c62e-45ac-b556-254c88fa0356"), null, 999m, "Смартфон Xiaomi Redmi Note 12S Onyx Black оснащен дисплеем диагональю 6,43 дюйма, выполненным по технологии AMOLED.", null, "Xiaomi_Redmi_Note_12S_256GB_Onyx_Black_smartphone_1.jpg", "Смартфон Xiaomi Redmi Note 12S 256GB Onyx Black" },
                    { new Guid("6f5d347c-0213-4b74-b7e9-825769e8dff0"), null, 679999m, "Телевизор LG OLED83C3RLA отличается диагональю экрана 83. Разрешение экрана — 4К. Устройство выполнено на базе технологии Dolby Vision, благодаря чему картинка будет всегда оставаться яркой, контрастной и насыщенной", null, "LG_OLED83C3RLA_TV_set_1.jpg", "Телевизор LG OLED83C3RLA" },
                    { new Guid("be023844-1854-48aa-bdb3-3379eabd0b66"), null, 129999m, "Игровой ноутбук Thunderobot 911 M G2 Pro 7 представлен в пластиковом корпусе серого цвета — модель с предустановленной ОС Windows 11, время автономной работы которой достигает 4,5 часов.", null, "Thunderobot_911_M_G2_Pro_7_gaming_laptop_J090DRU_1.jpg", "Ноутбук игровой Thunderobot 911 M G2 Pro 7 J090DRU" },
                    { new Guid("ec84b870-b3fa-448e-8875-720933600fb6"), null, 311199m, "Компактный духовой шкаф Kuppersbusch CBP 65 стильно выглядит и предоставляет широкие возможности для приготовления повседневной еды и угощения на праздничный стол.", null, "Kuppersbusch_CBP_6550.0_W2_Black_Chrome_Premium_Compact_Oven_1.jpg", "Компактный духовой шкаф Премиум Kuppersbusch CBP 65 W2 Black Chrome" },
                    { new Guid("1222bbf4-c548-482f-9d76-7709be44fde2"), null, 314999m, "Игровой ноутбук MSI Raider GE78 HX 13VH-5RU (MS-17S1) — модель в пластиковом корпусе черного цвета, которая поставляется с предустановленной ОС Windows 11 «Домашняя».", null, "MSI_Raider_GE78_HX_13VH-205RU_Gaming_Notebook_(MS-17S1)_1.jpg", "Ноутбук игровой MSI Raider GE78 HX 13VH-5RU (MS-17S1)" },
                    { new Guid("6c7fa342-5970-46b7-9500-1ffe70fab723"), null, 658999m, "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S представлен в корпусе черного цвета.", null, "Refrigerator_Kuppersbusch_FKG_98_S_1.jpg", "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S" },
                    { new Guid("66a140bc-8efd-4e08-bbe9-c278fbfc0a15"), null, 78999m, "Смартфон Nothing Phone 2 Dark Gray (65) — 6,55-дюймовый экран с матрицей OLED, поддерживающий разрешение 2412х пикселей.", null, "Nothing_Phone_12_256GB_Dark_Gray_(65)_Smartphone_1.jpg", "Смартфон Nothing Phone 12/256GB Dark Gray (65)" },
                    { new Guid("23b81070-070e-4ca2-a999-b10ff012dcda"), null, 93999m, "Холодильник Haier HRF-541DG7RU — это устройство Side-by-Side с множеством функций, которые помогут в повседневной жизни.", null, "Refrigerator_(Side-by-Side)_Haier_HRF-541DG7RU_1.jpg", "Холодильник (Side-by-Side) Haier HRF-541DG7RU" },
                    { new Guid("879aaa47-dcdc-486d-8315-7b4ce6cb7844"), null, 27999m, "Beko WSPE7612W – узкая стиральная машина, которая точно поместится в вашей ванной комнате.", null, "Beko_WSPE7612W_narrow_washing_machine_1.jpg", "Стиральная машина узкая Beko WSPE7612W" },
                    { new Guid("13c817a0-6bfb-4137-b1bb-0273302e0866"), null, 24999m, "Смартфон Honor X9A 59ALXQ, черный — модель среднего класса с экраном диагональю 6,67 дюймов и премиальным дизайном.", null, "HONOR X9a_6_128GB_5109ALXQ_Black_smartphone_1.jpg", "Смартфон HONOR X9a 6/128GB 59ALXQ Black" },
                    { new Guid("59635351-c567-43e1-9891-f6e7796af0b3"), null, 999m, "Консоль PlayStation 5 CFI-120/16/18)A оборудована внутренним хранилищем данных емкостью 825 Гб. Этот вид консоли поддерживает воспроизводство формата Blu-Ray и технологию HDR.", null, "Sony_PlayStation_5_Blu-ray_Edition_Console_CFI-12_1.jpg", "Консоль Sony PlayStation 5 Blu-Ray Edition CFI-120/16/18)A" },
                    { new Guid("3d32ceb7-56a2-4d2d-9a26-0cb4fc928f73"), null, 999m, "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.", null, "Built-in_electric_panel_Gorenje_ECT641BX_1.jpg", "Встраиваемая электрическая панель Gorenje ECT641BX" },
                    { new Guid("79655bba-f6b7-4615-b3fa-f8c7c37be4bd"), null, 21999m, "Холодильник Midea MDRB499FG1IM", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("1b42cd70-3785-44bb-b23c-a15c599741bb"), null, 19999m, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.", null, "Freezer_Haier_HF-82WAA_1.jpg", "Морозильная камера Haier HF-82WAA" },
                    { new Guid("f65dbd2e-3b78-4b6e-8922-4acff5e045e7"), null, 25999m, "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.", null, "Air_conditioner_Haier_HSU7HRM3_1.jpg", "Сплит-система Haier HSU7HRM3/R3" },
                    { new Guid("66d553e3-24ba-4a05-958b-50fd9ed4e34c"), null, 29999m, "Gorenje BO67372X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.", null, "Electric_oven_Gorenje_BO67372X_1.jpg", "Электрический духовой шкаф Gorenje BO67372X" },
                    { new Guid("e43937c7-27c9-4bb8-a1bf-132604f47530"), null, 18999m, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки", null, "Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg", "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White" },
                    { new Guid("614afee2-f3d9-42b8-8278-43362d763749"), null, 79999m, "Холодильник Midea MDRB499FG1IM, белый оснащен холодильной камерой объемом 2 л и нижней морозильной камерой объемом 76 л.", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("ca518ecd-bf43-4bcd-8d98-77e3e77f806b"), null, 69999m, "Телевизор Samsung QE43QBAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки. ", null, "tv_Samsung_QE43QBAU_1.jpg", "Телевизор Samsung QE43QBAU1" },
                    { new Guid("13da740f-e671-4ca6-881f-47adad50ee40"), null, 199999m, "Складной смартфон Samsung Galaxy Z Fold5 Phantom Black (SM-F946B) оснащен 7,6-дюймовым экраном разрешением 2176x1812 пикселей, обладающим пиковой яркостью 17 нит, что позволит смотреть кино или играть даже под солнечными лучами — изображение не поблекнет.", null, "Samsung_Galaxy_Z_Fold5_512GB_Phantom_Black_Smartphone_(SM-F946B)_1.jpg", "Смартфон Samsung Galaxy Z Fold5 512GB Phantom Black (SM-F946B)" },
                    { new Guid("a7582c8f-def4-4137-bac4-7445bfc48d4f"), null, 74999m, "Телевизор TCL 55C745 обладает габаритами 77х122х32 см. Вес устройства — 15 кг, без подставки — 13,5 кг.", null, "TV_TCL_55C745_1.jpg", "Телевизор TCL 55C745" }
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

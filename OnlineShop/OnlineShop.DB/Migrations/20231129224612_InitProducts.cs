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
                    { new Guid("afa4f9cc-875e-4ab3-a4a7-c6bc8c737821"), null, 99999m, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.", null, "notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg", "Ноутбук игровой MSI Katana 17 B12VEK-482XRU" },
                    { new Guid("24966232-1540-476e-91d0-fb3bf1f4e2b1"), null, 999m, "Смартфон Xiaomi Redmi Note 12S Onyx Black оснащен дисплеем диагональю 6,43 дюйма, выполненным по технологии AMOLED.", null, "Xiaomi_Redmi_Note_12S_256GB_Onyx_Black_smartphone_1.jpg", "Смартфон Xiaomi Redmi Note 12S 256GB Onyx Black" },
                    { new Guid("d24e16b6-d863-4b8d-82f1-b22b7eacfc72"), null, 679999m, "Телевизор LG OLED83C3RLA отличается диагональю экрана 83. Разрешение экрана — 4К. Устройство выполнено на базе технологии Dolby Vision, благодаря чему картинка будет всегда оставаться яркой, контрастной и насыщенной", null, "LG_OLED83C3RLA_TV_set_1.jpg", "Телевизор LG OLED83C3RLA" },
                    { new Guid("34338344-bf33-4743-a8a5-1627fd02c279"), null, 129999m, "Игровой ноутбук Thunderobot 911 M G2 Pro 7 представлен в пластиковом корпусе серого цвета — модель с предустановленной ОС Windows 11, время автономной работы которой достигает 4,5 часов.", null, "Thunderobot_911_M_G2_Pro_7_gaming_laptop_J090DRU_1.jpg", "Ноутбук игровой Thunderobot 911 M G2 Pro 7 J090DRU" },
                    { new Guid("39bbd48f-392f-4337-95ef-0f109db49112"), null, 311199m, "Компактный духовой шкаф Kuppersbusch CBP 65 стильно выглядит и предоставляет широкие возможности для приготовления повседневной еды и угощения на праздничный стол.", null, "Kuppersbusch_CBP_6550.0_W2_Black_Chrome_Premium_Compact_Oven_1.jpg", "Компактный духовой шкаф Премиум Kuppersbusch CBP 65 W2 Black Chrome" },
                    { new Guid("5a20552a-63ef-4881-8404-e7e69d395f1a"), null, 314999m, "Игровой ноутбук MSI Raider GE78 HX 13VH-5RU (MS-17S1) — модель в пластиковом корпусе черного цвета, которая поставляется с предустановленной ОС Windows 11 «Домашняя».", null, "MSI_Raider_GE78_HX_13VH-205RU_Gaming_Notebook_(MS-17S1)_1.jpg", "Ноутбук игровой MSI Raider GE78 HX 13VH-5RU (MS-17S1)" },
                    { new Guid("a256fdc4-faf9-4d78-afda-1460fba736fe"), null, 658999m, "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S представлен в корпусе черного цвета.", null, "Refrigerator_Kuppersbusch_FKG_98_S_1.jpg", "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S" },
                    { new Guid("82f9ec43-c453-449d-a2b1-1edefb36132f"), null, 78999m, "Смартфон Nothing Phone 2 Dark Gray (65) — 6,55-дюймовый экран с матрицей OLED, поддерживающий разрешение 2412х пикселей.", null, "Nothing_Phone_12_256GB_Dark_Gray_(65)_Smartphone_1.jpg", "Смартфон Nothing Phone 12/256GB Dark Gray (65)" },
                    { new Guid("d79c8f8c-e9ff-4b2c-ae61-8d9340eca014"), null, 93999m, "Холодильник Haier HRF-541DG7RU — это устройство Side-by-Side с множеством функций, которые помогут в повседневной жизни.", null, "Refrigerator_(Side-by-Side)_Haier_HRF-541DG7RU_1.jpg", "Холодильник (Side-by-Side) Haier HRF-541DG7RU" },
                    { new Guid("cfacfc6b-8e61-4c85-a3d5-a6b6bbdf2106"), null, 27999m, "Beko WSPE7612W – узкая стиральная машина, которая точно поместится в вашей ванной комнате.", null, "Beko_WSPE7612W_narrow_washing_machine_1.jpg", "Стиральная машина узкая Beko WSPE7612W" },
                    { new Guid("1557a26b-cb47-419b-8816-33b57b7ddfe6"), null, 24999m, "Смартфон Honor X9A 59ALXQ, черный — модель среднего класса с экраном диагональю 6,67 дюймов и премиальным дизайном.", null, "HONOR X9a_6_128GB_5109ALXQ_Black_smartphone_1.jpg", "Смартфон HONOR X9a 6/128GB 59ALXQ Black" },
                    { new Guid("83f4f42c-e529-49a6-8f32-49ed1d9a54c4"), null, 999m, "Консоль PlayStation 5 CFI-120/16/18)A оборудована внутренним хранилищем данных емкостью 825 Гб. Этот вид консоли поддерживает воспроизводство формата Blu-Ray и технологию HDR.", null, "Sony_PlayStation_5_Blu-ray_Edition_Console_CFI-12_1.jpg", "Консоль Sony PlayStation 5 Blu-Ray Edition CFI-120/16/18)A" },
                    { new Guid("68b59fee-264c-4e8f-bd54-e815f58051ff"), null, 999m, "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.", null, "Built-in_electric_panel_Gorenje_ECT641BX_1.jpg", "Встраиваемая электрическая панель Gorenje ECT641BX" },
                    { new Guid("74bca403-ee58-4e58-9de6-0e13bb886447"), null, 21999m, "Холодильник Midea MDRB499FG1IM", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("31aba571-2da3-4a30-b49b-4380e79c4ea8"), null, 19999m, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.", null, "Freezer_Haier_HF-82WAA_1.jpg", "Морозильная камера Haier HF-82WAA" },
                    { new Guid("138d5614-e639-4d26-a1ed-4b117284d849"), null, 25999m, "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.", null, "Air_conditioner_Haier_HSU7HRM3_1.jpg", "Сплит-система Haier HSU7HRM3/R3" },
                    { new Guid("661d0c78-17cf-4fd4-bd8a-8dd7e37be305"), null, 29999m, "Gorenje BO67372X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.", null, "Electric_oven_Gorenje_BO67372X_1.jpg", "Электрический духовой шкаф Gorenje BO67372X" },
                    { new Guid("68e0e94c-329f-494c-a8f4-75920587fc67"), null, 18999m, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки", null, "Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg", "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White" },
                    { new Guid("9d725523-4ce1-493d-85b7-ef71c6ae9f5f"), null, 79999m, "Холодильник Midea MDRB499FG1IM, белый оснащен холодильной камерой объемом 2 л и нижней морозильной камерой объемом 76 л.", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("f881707b-c11f-4826-8994-8b6754b9bd00"), null, 69999m, "Телевизор Samsung QE43QBAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки. ", null, "tv_Samsung_QE43QBAU_1.jpg", "Телевизор Samsung QE43QBAU1" },
                    { new Guid("d5b5ec07-c02b-4187-9253-157bc2d72438"), null, 199999m, "Складной смартфон Samsung Galaxy Z Fold5 Phantom Black (SM-F946B) оснащен 7,6-дюймовым экраном разрешением 2176x1812 пикселей, обладающим пиковой яркостью 17 нит, что позволит смотреть кино или играть даже под солнечными лучами — изображение не поблекнет.", null, "Samsung_Galaxy_Z_Fold5_512GB_Phantom_Black_Smartphone_(SM-F946B)_1.jpg", "Смартфон Samsung Galaxy Z Fold5 512GB Phantom Black (SM-F946B)" },
                    { new Guid("e44e8189-acfb-40e3-93e3-f1c02841f9cf"), null, 74999m, "Телевизор TCL 55C745 обладает габаритами 77х122х32 см. Вес устройства — 15 кг, без подставки — 13,5 кг.", null, "TV_TCL_55C745_1.jpg", "Телевизор TCL 55C745" }
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

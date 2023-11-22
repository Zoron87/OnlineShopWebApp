using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.DB.Migrations
{
    public partial class AddInitProducts : Migration
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
                    { new Guid("27a322ab-8741-480d-baca-6455fc6bb941"), null, 99999m, "Игровой ноутбук MSI Katana 17 B12VEK-482XRU выполнен в пластиковом корпусе размерами 25,2х398х273 мм и весом 2,6 кг.", null, "notebook_MSI_Katana_17_B12VEK-482XRU_1.jpg", "Ноутбук игровой MSI Katana 17 B12VEK-482XRU" },
                    { new Guid("16459fdc-0b0e-43e6-ac94-c25f2db4d2c0"), null, 999m, "Смартфон Xiaomi Redmi Note 12S Onyx Black оснащен дисплеем диагональю 6,43 дюйма, выполненным по технологии AMOLED.", null, "Xiaomi_Redmi_Note_12S_256GB_Onyx_Black_smartphone_1.jpg", "Смартфон Xiaomi Redmi Note 12S 256GB Onyx Black" },
                    { new Guid("5c1756fc-1158-4998-bf85-4a529f3b4942"), null, 679999m, "Телевизор LG OLED83C3RLA отличается диагональю экрана 83. Разрешение экрана — 4К. Устройство выполнено на базе технологии Dolby Vision, благодаря чему картинка будет всегда оставаться яркой, контрастной и насыщенной", null, "LG_OLED83C3RLA_TV_set_1.jpg", "Телевизор LG OLED83C3RLA" },
                    { new Guid("7b0e978a-216f-48cb-8bac-fe798c20946c"), null, 129999m, "Игровой ноутбук Thunderobot 911 M G2 Pro 7 представлен в пластиковом корпусе серого цвета — модель с предустановленной ОС Windows 11, время автономной работы которой достигает 4,5 часов.", null, "Thunderobot_911_M_G2_Pro_7_gaming_laptop_J090DRU_1.jpg", "Ноутбук игровой Thunderobot 911 M G2 Pro 7 J090DRU" },
                    { new Guid("32d8c66f-94ea-4d57-9f16-9f92be319a72"), null, 311199m, "Компактный духовой шкаф Kuppersbusch CBP 65 стильно выглядит и предоставляет широкие возможности для приготовления повседневной еды и угощения на праздничный стол.", null, "Kuppersbusch_CBP_65_W2_Black_Chrome_Premium_Compact_Oven_1.jpg", "Компактный духовой шкаф Премиум Kuppersbusch CBP 65 W2 Black Chrome" },
                    { new Guid("99e9feff-4716-4436-8c94-a270731ff1cc"), null, 314999m, "Игровой ноутбук MSI Raider GE78 HX 13VH-5RU (MS-17S1) — модель в пластиковом корпусе черного цвета, которая поставляется с предустановленной ОС Windows 11 «Домашняя».", null, "MSI_Raider_GE78_HX_13VH-5RU_Gaming_Notebook_(MS-17S1)_1.jpg", "Ноутбук игровой MSI Raider GE78 HX 13VH-5RU (MS-17S1)" },
                    { new Guid("d1f70630-c795-4791-83b7-a5f9c2cbeacd"), null, 658999m, "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S представлен в корпусе черного цвета.", null, "Refrigerator_Kuppersbusch_FKG_98_S_1.jpg", "Холодильник с нижней морозильной камерой Kuppersbusch FKG 98 S" },
                    { new Guid("1f15639a-e9bc-4b20-a5c3-cbbe40941971"), null, 78999m, "Смартфон Nothing Phone 2 Dark Gray (65) — 6,55-дюймовый экран с матрицей OLED, поддерживающий разрешение 2412х пикселей.", null, "Nothing_Phone_12_256GB_Dark_Gray_(65)_Smartphone_1.jpg", "Смартфон Nothing Phone 12/256GB Dark Gray (65)" },
                    { new Guid("58845c38-2f65-4627-83fe-5bac410c1f0b"), null, 93999m, "Холодильник Haier HRF-541DG7RU — это устройство Side-by-Side с множеством функций, которые помогут в повседневной жизни.", null, "Refrigerator_(Side-by-Side)_Haier_HRF-541DG7RU_1.jpg", "Холодильник (Side-by-Side) Haier HRF-541DG7RU" },
                    { new Guid("9f5aebd3-a023-415e-bb6f-119bbc440272"), null, 27999m, "Beko WSPE7612W – узкая стиральная машина, которая точно поместится в вашей ванной комнате.", null, "Beko_WSPE7612W_narrow_washing_machine_1.jpg", "Стиральная машина узкая Beko WSPE7612W" },
                    { new Guid("4afa22d0-0507-4692-8c13-9009bd03f28c"), null, 24999m, "Смартфон Honor X9A 59ALXQ, черный — модель среднего класса с экраном диагональю 6,67 дюймов и премиальным дизайном.", null, "HONOR X9a_6_128GB_59ALXQ_Black_smartphone_1.jpg", "Смартфон HONOR X9a 6/128GB 59ALXQ Black" },
                    { new Guid("6dd73216-53d9-45ef-9fcb-221eebfded1d"), null, 999m, "Консоль PlayStation 5 CFI-120/16/18)A оборудована внутренним хранилищем данных емкостью 825 Гб. Этот вид консоли поддерживает воспроизводство формата Blu-Ray и технологию HDR.", null, "Sony_PlayStation_5_Blu-ray_Edition_Console_CFI-12_1.jpg", "Консоль Sony PlayStation 5 Blu-Ray Edition CFI-120/16/18)A" },
                    { new Guid("cbb523ca-72ad-47be-af7a-fd15b4f7312c"), null, 999m, "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.", null, "Built-in_electric_panel_Gorenje_ECT641BX_1.jpg", "Встраиваемая электрическая панель Gorenje ECT641BX" },
                    { new Guid("cdfdaf2e-74f1-4b66-9e8e-be498574aeb3"), null, 21999m, "Планшет Honor Pad X9 Wi-Fi Space Gray 51AGJC функционирует на базе предустановленной ОС MagicOS 7.1.", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("307c53fe-b3fd-4a08-afd4-f0af7e498d43"), null, 19999m, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.", null, "Freezer_Haier_HF-82WAA_1.jpg", "Морозильная камера Haier HF-82WAA" },
                    { new Guid("94138c9b-ccea-42c0-88bd-8f565f12dddb"), null, 25999m, "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.", null, "Air_conditioner_Haier_HSU7HRM3_1.jpg", "Сплит-система Haier HSU7HRM3/R3" },
                    { new Guid("f508947e-1ad5-4866-85bf-e85300629536"), null, 29999m, "Gorenje BO67372X – электрический духовой шкаф с 77-литровой камерой BigSpace. За счёт внушительного объёма внутреннего пространства и его особой форме HomeMade вам будут по плечу самые смелые кулинарные эксперименты.", null, "Electric_oven_Gorenje_BO67372X_1.jpg", "Электрический духовой шкаф Gorenje BO67372X" },
                    { new Guid("1361d9db-4717-4b93-b7da-fb991e0d8d65"), null, 18999m, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки", null, "Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg", "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White" },
                    { new Guid("f830594d-db8f-4752-9fac-c892f6a8cff3"), null, 79999m, "Холодильник Midea MDRB499FG1IM, белый оснащен холодильной камерой объемом 2 л и нижней морозильной камерой объемом 76 л.", null, "Refrigerator_Midea_MDRB499FG1IM_1.jpg", "Холодильник Midea MDRB499FG1IM" },
                    { new Guid("cd86869c-da4e-4feb-96ef-0e9e464fbe28"), null, 69999m, "Телевизор Samsung QE43QBAU — модель, которая произведена по технологии QLED, что гарантирует вывод насыщенной и яркой картинки. ", null, "tv_Samsung_QE43QBAU_1.jpg", "Телевизор Samsung QE43QBAU1" },
                    { new Guid("d9b1386b-e798-4d42-995a-ef119abe8840"), null, 199999m, "Складной смартфон Samsung Galaxy Z Fold5 Phantom Black (SM-F946B) оснащен 7,6-дюймовым экраном разрешением 2176x1812 пикселей, обладающим пиковой яркостью 17 нит, что позволит смотреть кино или играть даже под солнечными лучами — изображение не поблекнет.", null, "Samsung_Galaxy_Z_Fold5_512GB_Phantom_Black_Smartphone_(SM-F946B)_1.jpg", "Смартфон Samsung Galaxy Z Fold5 512GB Phantom Black (SM-F946B)" },
                    { new Guid("07d40682-a299-4142-8122-87cc4f1eb264"), null, 74999m, "Телевизор TCL 55C745 обладает габаритами 77х122х32 см. Вес устройства — 15 кг, без подставки — 13,5 кг.", null, "TV_TCL_55C745_1.jpg", "Телевизор TCL 55C745" }
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

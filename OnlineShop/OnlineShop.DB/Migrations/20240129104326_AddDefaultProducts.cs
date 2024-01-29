using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompareId", "Cost", "Description", "FavouriteId", "Name" },
                values: new object[,]
                {
                    { new Guid("2842320a-f42d-4f81-880f-488778526f5d"), null, 19999m, "Компактная морозильная камера Haier HF-82WAA – хороший выбор для тех, кто хочет хранить дома или на даче запас замороженных продуктов и полуфабрикатов, а также делать домашние заготовки.", null, "Морозильная камера Haier HF-82WAA" },
                    { new Guid("6f74b568-cf38-4caa-92c3-dbc45437a2aa"), null, 25999m, "Сплит-система Haier HSU7HRM3/R3 в корпусе белого цвета заправлена хладагентом R 32. Устройство работает на охлаждение и обогрев. Модель рекомендована для установки в помещениях площадью до  м². В комплект входит пульт дистанционного управления с дисплеем.", null, "Сплит-система Haier HSU7HRM3/R3" },
                    { new Guid("7f15a38b-fcb6-4241-87e8-8148e148e5b4"), null, 9999m, "Встраиваемая электрическая панель Gorenje ECT641BX снабжена четырьмя конфорками, установленными под стеклокерамической поверхностью.", null, "Встраиваемая электрическая панель Gorenje ECT641BX" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("67dea053-c686-41a5-9e37-bf33ae82bada"), new Guid("6f74b568-cf38-4caa-92c3-dbc45437a2aa"), "/img/products/Air_conditioner_Haier_HSU7HRM3_2.jpg" },
                    { new Guid("a9ccb1f9-56e1-46f5-80f2-5391b9422750"), new Guid("2842320a-f42d-4f81-880f-488778526f5d"), "/img/products/Freezer_Haier_HF-82WAA_2.jpg" },
                    { new Guid("b5c66945-d510-49d7-811d-0383d46fdab8"), new Guid("7f15a38b-fcb6-4241-87e8-8148e148e5b4"), "/img/products/Built-in_electric_panel_Gorenje_ECT641BX_2.jpg" },
                    { new Guid("b6596218-042a-48b7-a62e-38ce8ed7ddd0"), new Guid("2842320a-f42d-4f81-880f-488778526f5d"), "/img/products/Freezer_Haier_HF-82WAA_1.jpg" },
                    { new Guid("cf1b1834-bdb7-4fbe-82a2-4dd06d635640"), new Guid("6f74b568-cf38-4caa-92c3-dbc45437a2aa"), "/img/products/Air_conditioner_Haier_HSU7HRM3_1.jpg" },
                    { new Guid("f5de0b00-1a25-4602-923d-661df4acc2f7"), new Guid("7f15a38b-fcb6-4241-87e8-8148e148e5b4"), "/img/products/Built-in_electric_panel_Gorenje_ECT641BX_1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("67dea053-c686-41a5-9e37-bf33ae82bada"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a9ccb1f9-56e1-46f5-80f2-5391b9422750"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b5c66945-d510-49d7-811d-0383d46fdab8"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b6596218-042a-48b7-a62e-38ce8ed7ddd0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cf1b1834-bdb7-4fbe-82a2-4dd06d635640"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5de0b00-1a25-4602-923d-661df4acc2f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2842320a-f42d-4f81-880f-488778526f5d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f74b568-cf38-4caa-92c3-dbc45437a2aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f15a38b-fcb6-4241-87e8-8148e148e5b4"));
        }
    }
}

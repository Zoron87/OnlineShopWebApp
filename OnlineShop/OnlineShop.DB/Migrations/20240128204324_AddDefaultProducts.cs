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
                values: new object[] { new Guid("1f06e50b-989b-4827-89db-4859d1d49998"), null, 18999m, "Робот-пылесос Dreame Bot Robot Vacuum and Mop D9 Pro White выполняет сухую и влажную уборку и способен обработать до 1 м² площади без подзарядки", null, "Робот-пылесос Dreame Bot Robot Vacuum and Mop F9 Pro White" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "URL" },
                values: new object[,]
                {
                    { new Guid("683efc32-0514-44a8-bda8-eb3ea45e3f42"), new Guid("1f06e50b-989b-4827-89db-4859d1d49998"), "/img/products/Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_2.jpg" },
                    { new Guid("e469883a-82d5-4b1e-9538-fe6d05dd1360"), new Guid("1f06e50b-989b-4827-89db-4859d1d49998"), "/img/products/Robot_Vacuum_Cleaner_Dreame_Bot_Robot_Vacuum_and_Mop_F9_Pro_1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("683efc32-0514-44a8-bda8-eb3ea45e3f42"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e469883a-82d5-4b1e-9538-fe6d05dd1360"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f06e50b-989b-4827-89db-4859d1d49998"));
        }
    }
}

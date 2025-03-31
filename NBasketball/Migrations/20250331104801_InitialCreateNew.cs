using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBasketball.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "Players",
                newName: "date_added");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_added",
                table: "Players",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "League", "Name" },
                values: new object[,]
                {
                    { 1, "NBA", "Los Angeles Lakers" },
                    { 2, "NBA", "Golden State Warriors" },
                    { 3, "NBA", "Chicago Bulls" },
                    { 4, "NBA", "Boston Celtics" },
                    { 5, "NBA", "Miami Heat" },
                    { 6, "ACB", "Real Madrid" },
                    { 7, "ACB", "FC Barcelona" },
                    { 8, "ACB", "Baskonia" },
                    { 9, "ACB", "Valencia Basket" },
                    { 10, "EuroLeague", "CSKA Moscow" },
                    { 11, "EuroLeague", "Anadolu Efes" },
                    { 12, "EuroLeague", "Fenerbahçe" },
                    { 13, "EuroLeague", "Olympiacos" },
                    { 14, "Greek League", "Panathinaikos" },
                    { 15, "Israeli League", "Maccabi Tel Aviv" },
                    { 16, "Italian League", "Virtus Bologna" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "date_added", "ImagePath", "Name", "Position", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/lebron.jpg", "Леброн Джеймс", "Форвард", 1 },
                    { 2, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/kavai.jpg", "Кавай Ленард", "Нападающий", 1 },
                    { 3, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/pol.jpg", "Пол Джордж", "Нападающий", 1 },
                    { 4, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/batler.jpg", "Джимми Батлер", "Нападающий", 3 },
                    { 5, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/steph.jpg", "Стефен Карри", "Защитник", 2 },
                    { 6, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/kevin.jpg", "Кевин Дюрант", "Форвард", 3 },
                    { 7, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/yanis.jpg", "Яннис Адетокунбо", "Форвард", 2 },
                    { 8, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/nikola.jpg", "Никола Йокич", "Центровой", 3 },
                    { 9, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/llull.jpg", "Серхио Льюль", "Защитник", 6 },
                    { 10, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/mirotic.jpg", "Никола Миротич", "Форвард", 7 },
                    { 11, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/satoransky.jpg", "Томас Саторански", "Защитник", 7 },
                    { 12, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/huertas.jpg", "Марсельиньо Уэртас", "Защитник", 8 },
                    { 13, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/decolo.jpg", "Нандо Де Коло", "Защитник", 10 },
                    { 14, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/micic.jpg", "Василие Мицич", "Защитник", 11 },
                    { 15, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/vesely.jpg", "Ян Веселы", "Центровой", 12 },
                    { 16, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), "/assets/sloukas.jpg", "Костас Слукас", "Защитник", 13 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.RenameColumn(
                name: "date_added",
                table: "Players",
                newName: "DateAdded");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Players",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProvinceAndCities.Data.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceCode", "ProvinceName" },
                values: new object[] { "QC", "Quebec" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityName", "Population", "ProvinceCode" },
                values: new object[,]
                {
                    { 5, "Quebec City", 15, "QC" },
                    { 6, "Montreal", 17, "QC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ProvinceCode",
                keyValue: "QC");
        }
    }
}

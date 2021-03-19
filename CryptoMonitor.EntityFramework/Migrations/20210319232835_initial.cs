using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace CryptoMonitor.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoCurrecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Ticker = table.Column<string>(type: "text", nullable: true),
                    CurrentPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HighestPrices",
                columns: table => new
                {
                    highestPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LowestPrices",
                columns: table => new
                {
                    lowestPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "CryptoCurrecies",
                columns: new[] { "Id", "CurrentPrice", "Ticker" },
                values: new object[,]
                {
                    { 1, 0.0, "BTC" },
                    { 2, 0.0, "ETH" },
                    { 3, 0.0, "BNB" },
                    { 4, 0.0, "USDT" },
                    { 5, 0.0, "ADA" },
                    { 6, 0.0, "DOT" },
                    { 7, 0.0, "XRP" },
                    { 8, 0.0, "UNI" },
                    { 9, 0.0, "LTC" },
                    { 10, 0.0, "LINK" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCurrecies");

            migrationBuilder.DropTable(
                name: "HighestPrices");

            migrationBuilder.DropTable(
                name: "LowestPrices");
        }
    }
}

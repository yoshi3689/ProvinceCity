using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProvinceCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceCode);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Population = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "ProvinceCode");
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceCode", "ProvinceName" },
                values: new object[,]
                {
                    { "AB", "Oilers" },
                    { "BC", "Canucks" },
                    { "CA", "Sharks" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "Population", "ProvinceCode" },
                values: new object[,]
                {
                    { 1, "Sven", 3, "CA" },
                    { 2, "Hendrik", 3, "CA" },
                    { 3, "John", 3, "CA" },
                    { 4, "Sven", 3, "BC" },
                    { 5, "Hendrik", 3, "BC" },
                    { 6, "John", 3, "BC" },
                    { 7, "Sven", 3, "AB" },
                    { 8, "Hendrik", 3, "AB" },
                    { 9, "John", 3, "AB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceCode",
                table: "City",
                column: "ProvinceCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}

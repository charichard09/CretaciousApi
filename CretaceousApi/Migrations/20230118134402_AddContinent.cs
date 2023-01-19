using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretaceousApi.Migrations
{
    public partial class AddContinent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    ContinentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.ContinentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContinentAnimals",
                columns: table => new
                {
                    ContinentAnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContinentId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentAnimals", x => x.ContinentAnimalId);
                    table.ForeignKey(
                        name: "FK_ContinentAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContinentAnimals_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "ContinentId", "Name" },
                values: new object[,]
                {
                    { 1, "North America" },
                    { 2, "South America" },
                    { 3, "Africa" },
                    { 4, "Europe" },
                    { 5, "Asia" },
                    { 6, "Australia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContinentAnimals_AnimalId",
                table: "ContinentAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_ContinentAnimals_ContinentId",
                table: "ContinentAnimals",
                column: "ContinentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContinentAnimals");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}

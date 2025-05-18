using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftGallery.Dominio.Migrations
{
    /// <inheritdoc />
    public partial class AddCampanhas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CampanhaId",
                table: "Produtos",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CampanhaId",
                table: "Produtos",
                column: "CampanhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Campanhas_CampanhaId",
                table: "Produtos",
                column: "CampanhaId",
                principalTable: "Campanhas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Campanhas_CampanhaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CampanhaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CampanhaId",
                table: "Produtos");
        }
    }
}

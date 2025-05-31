using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftGallery.Dominio.Migrations
{
    /// <inheritdoc />
    public partial class AjustesAddImagesCampanhas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemURL",
                table: "Campanhas",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemURL",
                table: "Campanhas");
        }
    }
}

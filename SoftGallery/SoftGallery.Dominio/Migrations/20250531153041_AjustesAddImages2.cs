using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftGallery.Dominio.Migrations
{
    /// <inheritdoc />
    public partial class AjustesAddImages2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemURL",
                table: "Produtos",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemURL",
                table: "Produtos");
        }
    }
}

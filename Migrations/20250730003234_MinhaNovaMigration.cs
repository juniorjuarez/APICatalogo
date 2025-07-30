using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoProdutos.API.Migrations
{
    /// <inheritdoc />
    public partial class MinhaNovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Categorias",
                newName: "ImagemUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Categorias",
                newName: "IagemUrl");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoProdutos.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos (Nome, Descricao, preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Coca-Cola Lata 350ml', 'Refrigerante tradicional em lata de 350ml.', 4.50, 'coca.jpg', 100, '2025-07-30 00:00:00', 1);");

            mb.Sql("INSERT INTO Produtos (Nome, Descricao, preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Cheeseburger Clássico', 'Hambúrguer artesanal com queijo cheddar, alface e molho especial.', 15.90, 'cheeseburger.jpg', 50, '2025-07-30 00:00:00', 3);");

            mb.Sql("INSERT INTO Produtos (Nome, Descricao, preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Torta de Limão', 'Sobremesa gelada com base crocante, recheio cremoso de limão e cobertura de chantilly.', 8.00, 'torta-limao.jpg', 30, '2025-07-30 00:00:00', 2);");
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}

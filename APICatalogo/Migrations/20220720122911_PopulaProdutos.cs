using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values('Coca-cola Diet','Refrigerante de Cola 350 ml',5.45,'cocacola-jpg',50,now(),1)");
            migrationBuilder.Sql("Insert Into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values('Lanche de atum','Lanche de atum com maionese',5.45,'atum-jpg',50,now(),2)");
            migrationBuilder.Sql("Insert Into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values('Pudim 100g','Pudim leite condensado de Cola 350 ml',5.45,'pudim-jpg',50,now(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from produtos");
        }
    }
}

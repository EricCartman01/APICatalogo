using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Categorias(Nome, ImagemUrl) values('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("Insert Into Categorias(Nome, ImagemUrl) values('Lanches','Lanches.jpg')");
            migrationBuilder.Sql("Insert Into Categorias(Nome, ImagemUrl) values('Sobremesas','Sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titular = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Data_Expiracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bandeira = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    CVV = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Prod = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Valor_unitario = table.Column<decimal>(type: "decimal", nullable: false),
                    Qtde_estoque = table.Column<int>(type: "int", nullable: false),
                    Data_Ultima_Venda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor_Ultima_Venda = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}

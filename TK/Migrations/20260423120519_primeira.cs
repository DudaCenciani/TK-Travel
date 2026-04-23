using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TK.Migrations
{
    /// <inheritdoc />
    public partial class primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadePessoas = table.Column<int>(type: "int", nullable: false),
                    TemCriancas = table.Column<bool>(type: "bit", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataViagem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantidadeDias = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrigemContato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promocao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "Promocao");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Migrations
{
    public partial class CreateTableLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QuadraId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Fim = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacoes_Quadras_QuadraId",
                        column: x => x.QuadraId,
                        principalTable: "Quadras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_QuadraId",
                table: "Locacoes",
                column: "QuadraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacoes");
        }
    }
}

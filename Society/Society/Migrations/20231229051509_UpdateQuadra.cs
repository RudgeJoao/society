using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society.Migrations
{
    public partial class UpdateQuadra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quadras",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quadras");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBooktopia.Migrations
{
    public partial class livroupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "LivrosModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "LivrosModel");
        }
    }
}

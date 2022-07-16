using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBooktopia.Migrations
{
    public partial class updatecliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "LivrosModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "LivrosModel");
        }
    }
}

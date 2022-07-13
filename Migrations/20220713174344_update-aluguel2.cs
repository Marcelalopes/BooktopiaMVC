using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBooktopia.Migrations
{
    public partial class updatealuguel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Devolvido",
                table: "AlugueisModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Devolvido",
                table: "AlugueisModel");
        }
    }
}

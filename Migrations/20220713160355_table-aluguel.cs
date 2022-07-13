using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBooktopia.Migrations
{
    public partial class tablealuguel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlugueisModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAluguel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlugueisModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlugueisModel_ClientesModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClientesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlugueisModel_LivrosModel_LivroId",
                        column: x => x.LivroId,
                        principalTable: "LivrosModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlugueisModel_ClienteId",
                table: "AlugueisModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AlugueisModel_LivroId",
                table: "AlugueisModel",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlugueisModel");
        }
    }
}

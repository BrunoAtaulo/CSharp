using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_1.Migrations
{
    public partial class Teste2Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Funcionarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

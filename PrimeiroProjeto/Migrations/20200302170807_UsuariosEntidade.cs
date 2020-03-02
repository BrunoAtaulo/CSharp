using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeiroProjeto.Migrations
{
    public partial class UsuariosEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}

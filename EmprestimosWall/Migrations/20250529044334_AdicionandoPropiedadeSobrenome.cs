using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosWall.Migrations
{
    public partial class AdicionandoPropiedadeSobrenome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Usuarios");
        }
    }
}

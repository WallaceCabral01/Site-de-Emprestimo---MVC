using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosWall.Migrations
{
    public partial class AddDataEmprestimoToEmprestimos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataUltimaAtuazacao",
                table: "Emprestimos",
                newName: "DataEmprestimo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataEmprestimo",
                table: "Emprestimos",
                newName: "DataUltimaAtuazacao");
        }
    }
}

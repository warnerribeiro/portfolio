using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class CorrecaoNomeId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountableId",
                table: "Responsavel",
                newName: "ResponsavelId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Aluno",
                newName: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponsavelId",
                table: "Responsavel",
                newName: "AccountableId");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Aluno",
                newName: "StudentId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class CorrecaoNomeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsavel_Aluno_AlunoId",
                table: "Responsavel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsavel",
                table: "Responsavel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Aluno");

            migrationBuilder.AddColumn<int>(
                name: "AccountableId",
                table: "Responsavel",
                nullable: false,
                defaultValue: 0,
                comment: "Chave primaria auto incremente")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Aluno",
                nullable: false,
                defaultValue: 0,
                comment: "Chave Primaria auto incremente")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsavel",
                table: "Responsavel",
                column: "AccountableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsavel_Aluno_AlunoId",
                table: "Responsavel",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsavel_Aluno_AlunoId",
                table: "Responsavel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsavel",
                table: "Responsavel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "AccountableId",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Aluno");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Responsavel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Chave primaria auto incremente")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Aluno",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Chave Primaria auto incremente")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsavel",
                table: "Responsavel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsavel_Aluno_AlunoId",
                table: "Responsavel",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

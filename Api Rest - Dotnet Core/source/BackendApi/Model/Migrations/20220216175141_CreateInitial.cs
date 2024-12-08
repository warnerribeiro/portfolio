using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, comment: "Chave Primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascimento = table.Column<DateTime>(type: "DATE", nullable: false, comment: "Data de Nascimento do aluno"),
                    Email = table.Column<string>(unicode: false, maxLength: 60, nullable: true, comment: "Email do aluno"),
                    ImagemPerfil = table.Column<byte[]>(nullable: true, comment: "Imagem de perfil do aluno"),
                    Nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false, comment: "Nome do aluno"),
                    Segmento = table.Column<string>(unicode: false, maxLength: 35, nullable: true, comment: "Segmento do aluno, infantil ou médio")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(nullable: false, comment: "Chave estrangeira do aluno"),
                    DataNascimento = table.Column<DateTime>(type: "DATE", nullable: false, comment: "Data de nascimento do aluno"),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false, comment: "Email do aluno, obrigatório"),
                    Nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false, comment: "Nome do responsável"),
                    Parentesco = table.Column<string>(unicode: false, maxLength: 25, nullable: true, comment: "Parentesco do responsável do aluno"),
                    Telefone = table.Column<string>(unicode: false, maxLength: 13, nullable: true, comment: "Telefone do responsável")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsavel_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_AlunoId",
                table: "Responsavel",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsavel");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}

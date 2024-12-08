using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class FixUserTablePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuario",
                newName: "Senha");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                unicode: false,
                nullable: true,
                comment: "Senha do usuario",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true,
                oldComment: "Senha do usuario");
        }
    }
}

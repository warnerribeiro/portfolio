using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class SeedingDataUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuario",
                newName: "NomeUsuario");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Usuario",
                newName: "Papel");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Usuario",
                newName: "UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Usuario",
                unicode: false,
                nullable: true,
                comment: "Salt para geração de cryptografia de senha",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Usuario",
                unicode: false,
                maxLength: 30,
                nullable: true,
                comment: "Nome de usuario de logn",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Papel",
                table: "Usuario",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "2, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Password", "Papel", "Salt", "NomeUsuario" },
                values: new object[] { 1, "", "ADMIN", "", "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "User",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Papel",
                table: "User",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "User",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true,
                oldComment: "Salt para geração de cryptografia de senha");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Nome de usuario de logn");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "2, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class FixTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Senha", "Salt" },
                values: new object[] { "zVg6mybEZzlcpJ/v7w4KonqBg9d96+FAVynlIUwgQSA=", "8uP3MaIFQIt726uSaH0BFg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Senha", "Salt" },
                values: new object[] { "", "" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    AssuntoId = table.Column<int>(type: "int", nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "Descrição do assunto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.AssuntoId);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Nome do ator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Titulo do Livro"),
                    Editora = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Editora do Livro"),
                    Edicao = table.Column<int>(type: "int", unicode: false, nullable: false, comment: "Edição do Livro"),
                    AnoPublicacao = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false, comment: "Ano de Publicação do Livro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.LivroId);
                });

            migrationBuilder.CreateTable(
                name: "OrigemCompra",
                columns: table => new
                {
                    OrigemCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, comment: "Nome de origem da compra")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigemCompra", x => x.OrigemCompraId);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    AssuntoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => new { x.LivroId, x.AssuntoId });
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Assunto_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assunto",
                        principalColumn: "AssuntoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.LivroId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroValor",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    OrigemCompraId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroValor", x => new { x.LivroId, x.OrigemCompraId });
                    table.ForeignKey(
                        name: "FK_LivroValor_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroValor_OrigemCompra_OrigemCompraId",
                        column: x => x.OrigemCompraId,
                        principalTable: "OrigemCompra",
                        principalColumn: "OrigemCompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrigemCompra",
                columns: new[] { "OrigemCompraId", "Nome" },
                values: new object[,]
                {
                    { 1, "Balcão" },
                    { 2, "Banca" },
                    { 3, "Evento" },
                    { 4, "Internet" },
                    { 5, "Self-Service" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_AssuntoId",
                table: "LivroAssunto",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_LivroId",
                table: "LivroAssunto",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_AutorId",
                table: "LivroAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_LivroId",
                table: "LivroAutor",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroValor_LivroId",
                table: "LivroValor",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroValor_OrigemCompraId",
                table: "LivroValor",
                column: "OrigemCompraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "LivroValor");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "OrigemCompra");
        }
    }
}

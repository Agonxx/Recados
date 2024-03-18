using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Recados.API.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Genero", "Nome" },
                values: new object[,]
                {
                    { 1, "Rafael@gmail.com", 1, "Rafael" },
                    { 2, "Fernando@gmail.com", 1, "Fernando" }
                });

            migrationBuilder.InsertData(
                table: "Recados",
                columns: new[] { "Id", "Mensagem", "Titulo", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Mensagem Recado 1", "Título Recado 1", 1 },
                    { 2, "Mensagem Recado 2", "Título Recado 2", 1 },
                    { 3, "Mensagem Recado 3", "Título Recado 3", 1 },
                    { 4, "Mensagem Recado 4", "Título Recado 4", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recados_UsuarioId",
                table: "Recados",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recados");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

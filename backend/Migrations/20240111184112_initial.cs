using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinoReservado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: true),
                    DestinoId = table.Column<int>(type: "int", nullable: true),
                    DateCheckin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCheckout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroAdultos = table.Column<int>(type: "int", nullable: false),
                    NumeroCriancas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoReservado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinoReservado_Destino_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DestinoReservado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinoReservado_DestinoId",
                table: "DestinoReservado",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinoReservado_UsuarioId",
                table: "DestinoReservado",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinoReservado");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

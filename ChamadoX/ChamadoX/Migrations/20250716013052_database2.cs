using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChamadoX.Migrations
{
    /// <inheritdoc />
    public partial class database2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tiket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoriaId = table.Column<string>(type: "text", nullable: false),
                    CategoriaModelCategoriaId = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<string>(type: "text", nullable: false),
                    StatusModelStatusId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiket_Categoria_CategoriaModelCategoriaId",
                        column: x => x.CategoriaModelCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "FK_Tiket_Statuses_StatusModelStatusId",
                        column: x => x.StatusModelStatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Nome" },
                values: new object[,]
                {
                    { "helpdesk", "Helpdesk" },
                    { "infraestrutura", "Infraestrutura" },
                    { "redes", "Redes" },
                    { "sistemas", "Sistemas" },
                    { "suportetecnico", "Suporte Técnico" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Nome" },
                values: new object[,]
                {
                    { "aberto", "Aberto" },
                    { "ematendimento", "Em Atendimento" },
                    { "finalizado", "Finalizado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tiket_CategoriaModelCategoriaId",
                table: "Tiket",
                column: "CategoriaModelCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiket_StatusModelStatusId",
                table: "Tiket",
                column: "StatusModelStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tiket");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}

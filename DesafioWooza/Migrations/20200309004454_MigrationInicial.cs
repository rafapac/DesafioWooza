using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioWooza.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanoTelefoniaTipo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoTelefoniaTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoTelefonia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Minutos = table.Column<int>(nullable: false),
                    FranquiaInternet = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    FkPlanoTelefoniaTipo = table.Column<Guid>(nullable: false),
                    Operadora = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoTelefonia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoTelefonia_PlanoTelefoniaTipo_FkPlanoTelefoniaTipo",
                        column: x => x.FkPlanoTelefoniaTipo,
                        principalTable: "PlanoTelefoniaTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoTelefoniaDDD",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DDD = table.Column<string>(maxLength: 2, nullable: false),
                    FkPlanoTelefonia = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoTelefoniaDDD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoTelefoniaDDD_PlanoTelefonia_FkPlanoTelefonia",
                        column: x => x.FkPlanoTelefonia,
                        principalTable: "PlanoTelefonia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlanoTelefoniaTipo",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { new Guid("91866764-ea96-4cbe-91f8-a10e36531f32"), "Controle" });

            migrationBuilder.InsertData(
                table: "PlanoTelefoniaTipo",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { new Guid("ee042bad-ec64-40d2-b7bb-e842871034c5"), "Pós" });

            migrationBuilder.InsertData(
                table: "PlanoTelefoniaTipo",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { new Guid("586d945a-a904-46c6-9b59-5fb16026a80c"), "Pré" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoTelefonia_FkPlanoTelefoniaTipo",
                table: "PlanoTelefonia",
                column: "FkPlanoTelefoniaTipo");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoTelefoniaDDD_FkPlanoTelefonia",
                table: "PlanoTelefoniaDDD",
                column: "FkPlanoTelefonia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoTelefoniaDDD");

            migrationBuilder.DropTable(
                name: "PlanoTelefonia");

            migrationBuilder.DropTable(
                name: "PlanoTelefoniaTipo");
        }
    }
}

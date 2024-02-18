using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPix.Data.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoChavePix = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinosPagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinosPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinosPagamentos_Chaves_ChaveId",
                        column: x => x.ChaveId,
                        principalTable: "Chaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrigensPagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigensPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrigensPagamentos_Chaves_ChaveId",
                        column: x => x.ChaveId,
                        principalTable: "Chaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrigemPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DestinoPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_DestinosPagamentos_DestinoPagamentoId",
                        column: x => x.DestinoPagamentoId,
                        principalTable: "DestinosPagamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transacoes_OrigensPagamentos_OrigemPagamentoId",
                        column: x => x.OrigemPagamentoId,
                        principalTable: "OrigensPagamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinosPagamentos_ChaveId",
                table: "DestinosPagamentos",
                column: "ChaveId");

            migrationBuilder.CreateIndex(
                name: "IX_OrigensPagamentos_ChaveId",
                table: "OrigensPagamentos",
                column: "ChaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_DestinoPagamentoId",
                table: "Transacoes",
                column: "DestinoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_OrigemPagamentoId",
                table: "Transacoes",
                column: "OrigemPagamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "DestinosPagamentos");

            migrationBuilder.DropTable(
                name: "OrigensPagamentos");

            migrationBuilder.DropTable(
                name: "Chaves");
        }
    }
}

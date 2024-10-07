using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_121 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropTable(
                name: "AgendamentoServico");

            migrationBuilder.AddColumn<int>(
                name: "TipoServicoId1",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servico_TipoServicoId1",
                table: "Servico",
                column: "TipoServicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Agendamento_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId1",
                table: "Servico",
                column: "TipoServicoId1",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Agendamento_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId1",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_TipoServicoId1",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "TipoServicoId1",
                table: "Servico");

            migrationBuilder.CreateTable(
                name: "AgendamentoServico",
                columns: table => new
                {
                    AgendamentosId = table.Column<int>(type: "int", nullable: false),
                    ServicosIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoServico", x => new { x.AgendamentosId, x.ServicosIdId });
                    table.ForeignKey(
                        name: "FK_AgendamentoServico_Agendamento_AgendamentosId",
                        column: x => x.AgendamentosId,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoServico_Servico_ServicosIdId",
                        column: x => x.ServicosIdId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoServico_ServicosIdId",
                table: "AgendamentoServico",
                column: "ServicosIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

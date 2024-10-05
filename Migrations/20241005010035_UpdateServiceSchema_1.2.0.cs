using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Servico_ServicoId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_ServicoId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "ServicosId",
                table: "Agendamento");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoServico");

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Agendamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicosId",
                table: "Agendamento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ServicoId",
                table: "Agendamento",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Servico_ServicoId",
                table: "Agendamento",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id");
        }
    }
}

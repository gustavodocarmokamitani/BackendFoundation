using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Agendamento_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId1",
                table: "Servico");

            migrationBuilder.RenameColumn(
                name: "TipoServicoId1",
                table: "Servico",
                newName: "AgendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_TipoServicoId1",
                table: "Servico",
                newName: "IX_Servico_AgendamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Agendamento_AgendamentoId",
                table: "Servico",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Agendamento_AgendamentoId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.RenameColumn(
                name: "AgendamentoId",
                table: "Servico",
                newName: "TipoServicoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_AgendamentoId",
                table: "Servico",
                newName: "IX_Servico_TipoServicoId1");

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
    }
}

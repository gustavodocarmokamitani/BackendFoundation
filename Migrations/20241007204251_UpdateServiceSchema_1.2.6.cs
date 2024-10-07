using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_126 : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Servico_TipoServicoId1",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "TipoServicoId1",
                table: "Servico");

            migrationBuilder.AddColumn<int>(
                name: "AgendamentosId",
                table: "Servico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicosId",
                table: "Agendamento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_AgendamentosId",
                table: "Servico",
                column: "AgendamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Agendamento_AgendamentosId",
                table: "Servico",
                column: "AgendamentosId",
                principalTable: "Agendamento",
                principalColumn: "Id");

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
                name: "FK_Servico_Agendamento_AgendamentosId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_AgendamentosId",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "AgendamentosId",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "ServicosId",
                table: "Agendamento");

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
    }
}

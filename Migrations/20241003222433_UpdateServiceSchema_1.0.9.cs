using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Servico_ServicoId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Agendamento_AgendamentoId",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_AgendamentoId",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "AgendamentoId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Agendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Servicos",
                table: "Agendamento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Servico_ServicoId",
                table: "Agendamento",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Servico_ServicoId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Servicos",
                table: "Agendamento");

            migrationBuilder.AddColumn<int>(
                name: "AgendamentoId",
                table: "Servico",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servico_AgendamentoId",
                table: "Servico",
                column: "AgendamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Servico_ServicoId",
                table: "Agendamento",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Agendamento_AgendamentoId",
                table: "Servico",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Cabeleleiro_CabeleireiroId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Cabeleleiro_CabeleireiroId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleireiroId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoServico_Cabeleleiro_CabeleireiroId",
                table: "TipoServico");

            migrationBuilder.DropIndex(
                name: "IX_TipoServico_CabeleireiroId",
                table: "TipoServico");

            migrationBuilder.DropColumn(
                name: "CabeleireiroId",
                table: "TipoServico");

            migrationBuilder.DropColumn(
                name: "AvaliacaoMedia",
                table: "Cabeleleiro");

            migrationBuilder.RenameColumn(
                name: "CabeleireiroId",
                table: "Servico",
                newName: "CabeleleiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_CabeleireiroId",
                table: "Servico",
                newName: "IX_Servico_CabeleleiroId");

            migrationBuilder.RenameColumn(
                name: "CabeleireiroId",
                table: "Avaliacao",
                newName: "CabeleleiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_CabeleireiroId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_CabeleleiroId");

            migrationBuilder.RenameColumn(
                name: "CabeleireiroId",
                table: "Agendamento",
                newName: "CabeleleiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_CabeleireiroId",
                table: "Agendamento",
                newName: "IX_Agendamento_CabeleleiroId");

            migrationBuilder.CreateTable(
                name: "CabeleleiroEspecialidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CabeleleiroId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabeleleiroEspecialidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabeleleiroEspecialidade_Cabeleleiro_CabeleleiroId",
                        column: x => x.CabeleleiroId,
                        principalTable: "Cabeleleiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabeleleiroEspecialidade_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CabeleleiroEspecialidade_CabeleleiroId",
                table: "CabeleleiroEspecialidade",
                column: "CabeleleiroId");

            migrationBuilder.CreateIndex(
                name: "IX_CabeleleiroEspecialidade_ServicoId",
                table: "CabeleleiroEspecialidade",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Cabeleleiro_CabeleleiroId",
                table: "Agendamento",
                column: "CabeleleiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Cabeleleiro_CabeleleiroId",
                table: "Avaliacao",
                column: "CabeleleiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleleiroId",
                table: "Servico",
                column: "CabeleleiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Cabeleleiro_CabeleleiroId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Cabeleleiro_CabeleleiroId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleleiroId",
                table: "Servico");

            migrationBuilder.DropTable(
                name: "CabeleleiroEspecialidade");

            migrationBuilder.RenameColumn(
                name: "CabeleleiroId",
                table: "Servico",
                newName: "CabeleireiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_CabeleleiroId",
                table: "Servico",
                newName: "IX_Servico_CabeleireiroId");

            migrationBuilder.RenameColumn(
                name: "CabeleleiroId",
                table: "Avaliacao",
                newName: "CabeleireiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_CabeleleiroId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_CabeleireiroId");

            migrationBuilder.RenameColumn(
                name: "CabeleleiroId",
                table: "Agendamento",
                newName: "CabeleireiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_CabeleleiroId",
                table: "Agendamento",
                newName: "IX_Agendamento_CabeleireiroId");

            migrationBuilder.AddColumn<int>(
                name: "CabeleireiroId",
                table: "TipoServico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "AvaliacaoMedia",
                table: "Cabeleleiro",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoServico_CabeleireiroId",
                table: "TipoServico",
                column: "CabeleireiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Cabeleleiro_CabeleireiroId",
                table: "Agendamento",
                column: "CabeleireiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Cabeleleiro_CabeleireiroId",
                table: "Avaliacao",
                column: "CabeleireiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleireiroId",
                table: "Servico",
                column: "CabeleireiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoServico_Cabeleleiro_CabeleireiroId",
                table: "TipoServico",
                column: "CabeleireiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id");
        }
    }
}

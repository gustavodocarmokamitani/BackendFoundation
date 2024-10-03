using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabeleleiroEspecialidade");

            migrationBuilder.AddColumn<string>(
                name: "ServicosId",
                table: "Cabeleleiro",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicosId",
                table: "Cabeleleiro");

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
        }
    }
}

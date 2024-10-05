using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_117 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Cabeleleiro");

            migrationBuilder.RenameColumn(
                name: "CabeleleiroId",
                table: "Servico",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_CabeleleiroId",
                table: "Servico",
                newName: "IX_Servico_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "CabeleleiroId",
                table: "Avaliacao",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_CabeleleiroId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "CabeleleiroId",
                table: "Agendamento",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_CabeleleiroId",
                table: "Agendamento",
                newName: "IX_Agendamento_FuncionarioId");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ServicosId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Funcionario_FuncionarioId",
                table: "Agendamento",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Funcionario_FuncionarioId",
                table: "Avaliacao",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioId",
                table: "Servico",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Funcionario_FuncionarioId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Funcionario_FuncionarioId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioId",
                table: "Servico");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Servico",
                newName: "CabeleleiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_FuncionarioId",
                table: "Servico",
                newName: "IX_Servico_CabeleleiroId");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Avaliacao",
                newName: "CabeleleiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_FuncionarioId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_CabeleleiroId");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Agendamento",
                newName: "CabeleleiroId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_FuncionarioId",
                table: "Agendamento",
                newName: "IX_Agendamento_CabeleleiroId");

            migrationBuilder.CreateTable(
                name: "Cabeleleiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ServicosId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabeleleiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabeleleiro_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cabeleleiro_UsuarioId",
                table: "Cabeleleiro",
                column: "UsuarioId");

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
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "MetodoPagamento",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "StatusPagamento",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "AnosExperiencia",
                table: "Cabeleleiro");

            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Cabeleleiro");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "DuracaoMinutos",
                table: "Servico",
                newName: "TipoServicoId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgendamentoId",
                table: "Servico",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ValorPago",
                table: "Pagamento",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MetodoPagamentoId",
                table: "Pagamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusPagamentoId",
                table: "Pagamento",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "AvaliacaoMedia",
                table: "Cabeleleiro",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "StatusAgendamentoId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MetodoPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatusAgendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAgendamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatusPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPagamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DuracaoMinutos = table.Column<int>(type: "int", nullable: false),
                    CabeleireiroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoServico_Cabeleleiro_CabeleireiroId",
                        column: x => x.CabeleireiroId,
                        principalTable: "Cabeleleiro",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_AgendamentoId",
                table: "Servico",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_MetodoPagamentoId",
                table: "Pagamento",
                column: "MetodoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_StatusPagamentoId",
                table: "Pagamento",
                column: "StatusPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_StatusAgendamentoId",
                table: "Agendamento",
                column: "StatusAgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoServico_CabeleireiroId",
                table: "TipoServico",
                column: "CabeleireiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuario_UsuarioId",
                table: "TipoUsuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_StatusAgendamento_StatusAgendamentoId",
                table: "Agendamento",
                column: "StatusAgendamentoId",
                principalTable: "StatusAgendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_MetodoPagamento_MetodoPagamentoId",
                table: "Pagamento",
                column: "MetodoPagamentoId",
                principalTable: "MetodoPagamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_StatusPagamento_StatusPagamentoId",
                table: "Pagamento",
                column: "StatusPagamentoId",
                principalTable: "StatusPagamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Agendamento_AgendamentoId",
                table: "Servico",
                column: "AgendamentoId",
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
                name: "FK_Agendamento_StatusAgendamento_StatusAgendamentoId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_MetodoPagamento_MetodoPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_StatusPagamento_StatusPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Agendamento_AgendamentoId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropTable(
                name: "MetodoPagamento");

            migrationBuilder.DropTable(
                name: "StatusAgendamento");

            migrationBuilder.DropTable(
                name: "StatusPagamento");

            migrationBuilder.DropTable(
                name: "TipoServico");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Servico_AgendamentoId",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_MetodoPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_StatusPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_StatusAgendamentoId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "AgendamentoId",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "MetodoPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "StatusPagamentoId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "StatusAgendamentoId",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "TipoServicoId",
                table: "Servico",
                newName: "DuracaoMinutos");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Telefone",
                keyValue: null,
                column: "Telefone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TipoUsuario",
                table: "Usuario",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Servico",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Servico",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "Servico",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "ValorPago",
                table: "Pagamento",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetodoPagamento",
                table: "Pagamento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StatusPagamento",
                table: "Pagamento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "AvaliacaoMedia",
                table: "Cabeleleiro",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnosExperiencia",
                table: "Cabeleleiro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Cabeleleiro",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Agendamento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

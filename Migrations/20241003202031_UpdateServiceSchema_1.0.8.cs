using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServiceSchema_108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleleiroId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "CabeleleiroId",
                table: "Servico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleleiroId",
                table: "Servico",
                column: "CabeleleiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleleiroId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "CabeleleiroId",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Cabeleleiro_CabeleleiroId",
                table: "Servico",
                column: "CabeleleiroId",
                principalTable: "Cabeleleiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starcatcher.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoDeDeletarUserCota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotas_Users_UserId",
                table: "Cotas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotas_Users_UserId",
                table: "Cotas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotas_Users_UserId",
                table: "Cotas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotas_Users_UserId",
                table: "Cotas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

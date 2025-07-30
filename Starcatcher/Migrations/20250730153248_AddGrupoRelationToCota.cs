using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starcatcher.Migrations
{
    /// <inheritdoc />
    public partial class AddGrupoRelationToCota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrupoId",
                table: "Cotas",
                newName: "GrupoConsorcioId");

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotalDoGrupo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotas_GrupoConsorcioId",
                table: "Cotas",
                column: "GrupoConsorcioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotas_Grupos_GrupoConsorcioId",
                table: "Cotas",
                column: "GrupoConsorcioId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotas_Grupos_GrupoConsorcioId",
                table: "Cotas");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Cotas_GrupoConsorcioId",
                table: "Cotas");

            migrationBuilder.RenameColumn(
                name: "GrupoConsorcioId",
                table: "Cotas",
                newName: "GrupoId");
        }
    }
}

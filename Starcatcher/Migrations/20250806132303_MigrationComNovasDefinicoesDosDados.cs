using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starcatcher.Migrations
{
    /// <inheritdoc />
    public partial class MigrationComNovasDefinicoesDosDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDeParcelas",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "ValorTotalDoGrupoComTaxa",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Cotas");

            migrationBuilder.RenameColumn(
                name: "Grupo",
                table: "Grupos",
                newName: "NomeDoGrupo");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotalDoGrupoSemTaxa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxaAdministrativa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeDeCotas",
                table: "Grupos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTaxaAdministrativa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorParcela",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDaCartaDeCredito",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPago",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "QteParcelas",
                table: "Cotas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCota",
                table: "Cotas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Atribuida",
                table: "Cotas",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTaxaAdministrativa",
                table: "Grupos");

            migrationBuilder.RenameColumn(
                name: "NomeDoGrupo",
                table: "Grupos",
                newName: "Grupo");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotalDoGrupoSemTaxa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxaAdministrativa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeDeCotas",
                table: "Grupos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeParcelas",
                table: "Grupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalDoGrupoComTaxa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorParcela",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDaCartaDeCredito",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPago",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QteParcelas",
                table: "Cotas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumeroCota",
                table: "Cotas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Atribuida",
                table: "Cotas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

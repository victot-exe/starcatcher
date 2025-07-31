using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starcatcher.Migrations
{
    /// <inheritdoc />
    public partial class GrupoCotaMigrationComRelacoes3107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorTotalDoGrupo",
                table: "Grupos",
                newName: "ValorTotalDoGrupoSemTaxa");

            migrationBuilder.RenameColumn(
                name: "ValorMensal",
                table: "Grupos",
                newName: "ValorTotalDoGrupoComTaxa");

            migrationBuilder.RenameColumn(
                name: "Parcela",
                table: "Cotas",
                newName: "ValorParcela");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Cotas",
                newName: "DataDeAtribuicao");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeCotas",
                table: "Grupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeParcelas",
                table: "Grupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaAdministrativa",
                table: "Grupos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Atribuida",
                table: "Cotas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QteParcelas",
                table: "Cotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDaCartaDeCredito",
                table: "Cotas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDeCotas",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "QuantidadeDeParcelas",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "TaxaAdministrativa",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Atribuida",
                table: "Cotas");

            migrationBuilder.DropColumn(
                name: "QteParcelas",
                table: "Cotas");

            migrationBuilder.DropColumn(
                name: "ValorDaCartaDeCredito",
                table: "Cotas");

            migrationBuilder.RenameColumn(
                name: "ValorTotalDoGrupoSemTaxa",
                table: "Grupos",
                newName: "ValorTotalDoGrupo");

            migrationBuilder.RenameColumn(
                name: "ValorTotalDoGrupoComTaxa",
                table: "Grupos",
                newName: "ValorMensal");

            migrationBuilder.RenameColumn(
                name: "ValorParcela",
                table: "Cotas",
                newName: "Parcela");

            migrationBuilder.RenameColumn(
                name: "DataDeAtribuicao",
                table: "Cotas",
                newName: "DataCriacao");
        }
    }
}

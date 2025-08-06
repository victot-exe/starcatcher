using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcatcher.Entities;

namespace Starcatcher.DTOs
{
    public record GrupoConsorcioExitDto(
        int Id,
        string NomeDoGrupo,
        decimal? ValorTotalDoGrupo,
        decimal? TaxaAdministrativa,
        decimal? ValorTaxaAdministrativa,
        int? QuantidadeDeCotas
    )
    {
        public GrupoConsorcioExitDto(GrupoConsorcio grupo) : this(grupo.Id, grupo.NomeDoGrupo, grupo.ValorTotalDoGrupoSemTaxa, grupo.TaxaAdministrativa, grupo.ValorTaxaAdministrativa, grupo.QuantidadeDeCotas){}
    }
}
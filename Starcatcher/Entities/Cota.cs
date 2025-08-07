using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Starcatcher.DTOs;

namespace Starcatcher.Entities
{

    public class Cota
    {
        public Cota() {}
        public Cota(CotaUpdateDto cota)
        {
            //TODO remover
        }

        public Cota(string numeroCota, int idGrupo, decimal valorParcela, decimal valorPago, decimal valorDaCartaDeCredito, int quantidadeDeParcelas, bool atribuida, DateOnly date)
        {
            NumeroCota = numeroCota.ToString();
            GrupoConsorcioId = idGrupo;
            ValorParcela = valorParcela;
            TotalPago = valorPago;
            ValorDaCartaDeCredito = valorDaCartaDeCredito;
            QteParcelas = quantidadeDeParcelas;
            Atribuida = atribuida;
            DataDeAtribuicao = date;
        }

        public int Id { get; set; }
        public string? NumeroCota { get; set; }
        public decimal? ValorParcela { get; set; }
        public decimal? TotalPago { get; set; }

        public DateOnly DataDeAtribuicao { get; set; }

        public int GrupoConsorcioId { get; set; }
        [JsonIgnore]
        public GrupoConsorcio GrupoConsorcio { get; set; } = null!;

        public decimal? ValorDaCartaDeCredito { get; set; }
        public bool? Atribuida { get; set; }
        public int? QteParcelas { get; set; }

        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public decimal? ValorTotal => QteParcelas * ValorParcela;
    }
}
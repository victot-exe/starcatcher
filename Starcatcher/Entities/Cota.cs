using System.Text.Json.Serialization;
using Starcatcher.DTOs;

namespace Starcatcher.Entities
{

    public class Cota
    {
        public Cota() { }
        public Cota(CotaDTOEntry cota, DateOnly date, GrupoConsorcio grupo)//TODO em service pegar o id do grupo e pegar um grupo existente ou criar um novo
        {
            DataDeAtribuicao = date;
            GrupoConsorcio = grupo;
        }
        public Cota(CotaDTOUpdate cota)
        {
            NumeroCota = cota.NumeroCota;
            ValorTotal = cota.ValorTotal;
            ValorParcela = cota.Parcela;
            TotalPago = cota.TotalPago;
            DataDeAtribuicao = cota.DataDeAtribuicao;
            GrupoConsorcio = cota.GrupoConsorcio;
        }

        public Cota(int numeroCota, int idGrupo, decimal valorParcela, decimal valorPago, decimal valorDaCartaDeCredito, int quantidadeDeParcelas, bool atribuida, DateOnly date)
        {
            NumeroCota = numeroCota;
            GrupoConsorcioId = idGrupo;
            ValorParcela = valorParcela;
            TotalPago = valorPago;
            ValorDaCartaDeCredito = valorDaCartaDeCredito;
            QteParcelas = quantidadeDeParcelas;
            Atribuida = atribuida;
            DataDeAtribuicao = date;
        }

        public int Id { get; set; }
        public int NumeroCota { get; set; }
        public decimal ValorTotal { get; set; }//acho que não precisa
        public decimal ValorParcela { get; set; }
        public decimal TotalPago { get; set; }
        public DateOnly DataDeAtribuicao { get; set; }
        [JsonIgnore]
        public GrupoConsorcio GrupoConsorcio { get; set; } = null!;
        public int GrupoConsorcioId { get; set; }//prop referente a FK
        public decimal ValorDaCartaDeCredito { get; set; }
        public bool Atribuida { get; set; }
        public int QteParcelas { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; } = new();
    }
}
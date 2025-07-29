namespace Starcatcher.DTOs
{
    public record CotaDTOEntry(int NumeroCota,
                                decimal ValorTotal,
                                decimal Parcela,
                                decimal TotalPago,
                                DateOnly DataCriacao,
                                int GrupoId)
    {
        
    }
}
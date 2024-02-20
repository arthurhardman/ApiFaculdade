namespace SistemaFaculdade.DataTransfer.PeriodosMaterias.Requests;

public class PeriodosMateriasAtualizarRequest
{
    public int Id { get; set; }
    public int IdPeriodo { get; set; }
    public int IdMateria { get; set; }
}
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.DataTransfer.Periodos.Responses;

public class PeriodosResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Turno { get; set; }
    public IList<Materia> Materias { get; set; }
}
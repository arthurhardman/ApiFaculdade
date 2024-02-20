using SistemaFaculdade.DataTransfer.Materias.Responses;
using SistemaFaculdade.DataTransfer.Periodos.Responses;

namespace SistemaFaculdade.DataTransfer.PeriodosMaterias.Responses;

public class PeriodosMateriasResponse
{
    public int Id { get; set; }
    public PeriodosResponse Periodo { get; set; }
    public MateriaResponse Materia { get; set; }
}
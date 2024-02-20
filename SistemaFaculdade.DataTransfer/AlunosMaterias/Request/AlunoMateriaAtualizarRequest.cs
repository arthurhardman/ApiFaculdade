namespace SistemaFaculdade.DataTransfer.AlunosMaterias.Request;

public class AlunoMateriaAtualizarRequest
{
    public int Id { get; set; }
    public int MatriculaAluno { get; set; }
    public int IdMateria { get; set; }
}
namespace SistemaFaculdade.DataTransfer.ProfessoresMaterias.Requests;

public class ProfessorMateriasAtualizarRequest
{
    public int Id { get; set; }
    public int IdProfessor { get; set; }
    public int IdMateria { get; set; }
}
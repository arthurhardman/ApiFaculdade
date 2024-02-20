using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Professores.Entidades;

namespace SistemaFaculdade.DataTransfer.ProfessoresMaterias.Responses;

public class ProfessorMateriasResponse
{
    public int Id { get; set; }
    public Professor Professor { get; set; }
    public Materia Materia { get; set; }
}
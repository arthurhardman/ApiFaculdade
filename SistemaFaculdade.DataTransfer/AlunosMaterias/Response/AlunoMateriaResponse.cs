using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.DataTransfer.AlunosMaterias.Response;

public class AlunoMateriaResponse
{
    public int Id { get; set; }
    public Aluno Aluno { get; set; }
    public Materia Materia { get; set; }
}
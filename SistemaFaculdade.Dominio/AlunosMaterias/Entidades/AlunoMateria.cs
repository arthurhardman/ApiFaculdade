using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.Dominio.AlunosMaterias.Entidades;

public class AlunoMateria
{
    public virtual int Id { get; protected set; }
    public virtual Aluno Aluno { get; protected set; }
    public virtual Materia Materia { get; protected set; }

    protected AlunoMateria() { }

    public AlunoMateria(Aluno aluno, Materia materia)
    {
        SetAluno(aluno);
        SetMateria(materia);
    }

    public virtual void SetAluno(Aluno aluno)
    {
        Aluno = aluno;
    }

    public virtual void SetMateria(Materia materia)
    {
        Materia = materia;
    }
}
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Professores.Entidades;

namespace SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;

public class ProfessorMateria
{
    public virtual int Id { get; protected set; }
    public virtual Professor Professor { get; protected set; }
    public virtual Materia Materia { get; protected set; }

    protected ProfessorMateria() { }

    public ProfessorMateria(Professor professor, Materia materia)
    {
        SetProfessor(professor);
        SetMateria(materia);
    }

    public virtual void SetProfessor(Professor professor)
    {
        Professor = professor;
    }

    public virtual void SetMateria(Materia materia)
    {
        Materia = materia;
    }
}
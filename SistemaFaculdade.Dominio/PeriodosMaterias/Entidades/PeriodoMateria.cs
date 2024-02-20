using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Periodos.Entidades;

namespace SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;

public class PeriodoMateria
{
    public virtual int Id { get; protected set; }
    public virtual Periodo Periodo { get; protected set; }
    public virtual Materia Materia { get; protected set; }

    protected PeriodoMateria() { }

    public PeriodoMateria(Periodo periodo, Materia materia)
    {
        SetPeriodo(periodo);
        SetMateria(materia);
    }

    public virtual void SetPeriodo(Periodo periodo)
    {
        Periodo = periodo;
    }

    public virtual void SetMateria(Materia materia)
    {
        Materia = materia;
    }
}
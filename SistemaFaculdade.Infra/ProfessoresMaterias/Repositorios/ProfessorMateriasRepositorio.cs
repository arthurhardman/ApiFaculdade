using NHibernate;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.ProfessoresMaterias.Repositorios;

public class ProfessorMateriasRepositorio : GenericoRepositorio<ProfessorMateria>, IProfessorMateriasRepositorio
{
    public ProfessorMateriasRepositorio(ISession session) : base(session)
    {
    }
}
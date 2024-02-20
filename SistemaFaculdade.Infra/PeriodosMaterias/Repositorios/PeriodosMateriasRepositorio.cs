using NHibernate;
using SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;
using SistemaFaculdade.Dominio.PeriodosMaterias.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.PeriodosMaterias.Repositorios;

public class PeriodosMateriasRepositorio : GenericoRepositorio<PeriodoMateria>, IPeriodoMateriaRepositorio
{
    public PeriodosMateriasRepositorio(ISession session) : base(session)
    {
    }
}
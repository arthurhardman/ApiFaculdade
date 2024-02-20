using NHibernate;
using SistemaFaculdade.Dominio.Periodos.Entidades;
using SistemaFaculdade.Dominio.Periodos.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Periodos.Repositorios;

public class PeriodosRepositorios : GenericoRepositorio<Periodo>, IPeriodoRepositorio
{
    public PeriodosRepositorios(ISession session) : base(session)
    {
    }
}
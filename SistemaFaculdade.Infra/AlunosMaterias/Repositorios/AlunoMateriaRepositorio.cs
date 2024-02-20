using NHibernate;
using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;
using SistemaFaculdade.Dominio.AlunosMaterias.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.AlunosMaterias.Repositorios;

public class AlunoMateriaRepositorio : GenericoRepositorio<AlunoMateria>, IAlunoMateriaRepositorio
{
    public AlunoMateriaRepositorio(ISession session) : base(session)
    {
    }

    public IList<AlunoMateria> Listar()
    {
        throw new NotImplementedException();
    }
}
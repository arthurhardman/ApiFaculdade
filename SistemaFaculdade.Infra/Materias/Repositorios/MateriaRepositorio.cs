using Dapper;
using NHibernate;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Materias.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Materias.Repositorios;

public class MateriaRepositorio : GenericoRepositorio<Materia>, IMateriaRepositorio
{
    public MateriaRepositorio(ISession session) : base(session)
    {
    }

    public IList<Materia> Listar(string nome)
    {
        string query = "SELECT * FROM materias m ";

        if (!string.IsNullOrEmpty(nome))
            query += $" WHERE m.nome LIKE '%{nome}%'";


        IList<Materia> materias = session.Connection.Query<Materia>(query).ToList();
        return materias;
    }
}
using Dapper;
using NHibernate;
using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Professores.Entidades;
using SistemaFaculdade.Dominio.Professores.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Professores.Repositorios;

public class ProfessorRepositorio : GenericoRepositorio<Professor>, IProfessorRepositorio
{
    public ProfessorRepositorio(ISession session) : base(session)
    {
    }

    public IList<Professor> Listar(string nome)
    {
        string query = $"SELECT * FROM professores p INNER JOIN endereco e ON e.id = p.idendereco INNER JOIN professormateria pm ON pm.idprofessor = p.id INNER JOIN materias m ON m.id = pm.idmateria";

        if (!string.IsNullOrEmpty(nome))
            query += $" WHERE p.Nome LIKE '%{nome}%'";

        IList<Professor> professores = session.Connection.Query<Professor, Endereco, Materia, Professor>(
        query,
            (professor, endereco, materia) =>
            {
                professor.SetEndereco(endereco);
                professor.Materias.Add(materia);
                return professor;
            },
            splitOn: "id, id"
        ).ToList();
        return professores;
    }

}
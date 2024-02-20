using Dapper;
using NHibernate;
using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Repositorios;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Alunos.Repositorios;

public class AlunoRepositorio : GenericoRepositorio<Aluno>, IAlunoRepositorio
{
    public AlunoRepositorio(ISession session) : base(session)
    {
    }

    public IList<Aluno> Listar(string nome)
    {
        string query = @"SELECT * 
                        FROM alunos a 
                        LEFT JOIN atividadesextras ae ON ae.MatriculaAluno = a.Matricula 
                        LEFT JOIN ocorrencias o ON o.MatriculaAluno = a.Matricula
                        INNER JOIN alunomateria am ON am.matriculaAluno = a.Matricula
                        INNER JOIN materias m ON m.id = am.idmateria";

        if (!string.IsNullOrEmpty(nome))
            query += $" WHERE a.nome LIKE '%{nome}%'";

        Dictionary<int, Aluno> alunoDictionary = new();

        IList<Aluno> alunos = session.Connection.Query<Aluno, AtividadeExtra, Ocorrencia, Materia, Aluno>(
        query,
        (aluno, atividadeextra, ocorrencia, materia) =>
        {
            if (!alunoDictionary.TryGetValue(aluno.Matricula, out var alunoEntry))
            {
                alunoEntry = aluno;
                alunoEntry.Materias = new List<Materia>();
                alunoEntry.AtividadeExtras = new List<AtividadeExtra>();
                alunoEntry.Ocorrencias = new List<Ocorrencia>();
                alunoDictionary.Add(alunoEntry.Matricula, alunoEntry);
            }

            alunoEntry.Materias.Add(materia);
            alunoEntry.AtividadeExtras.Add(atividadeextra);
            alunoEntry.Ocorrencias.Add(ocorrencia);

            return alunoEntry;
        }
        ).Distinct().ToList();

        return alunos;
    }
}
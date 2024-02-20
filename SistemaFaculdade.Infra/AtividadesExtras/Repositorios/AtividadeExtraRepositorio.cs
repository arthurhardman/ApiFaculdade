using Dapper;
using NHibernate;
using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.AtividadesExtras.Repositorios;
using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.AtividadesExtras.Repositorios;

public class AtividadeExtraRepositorio : GenericoRepositorio<AtividadeExtra>, IAtividadeExtraRepositorio
{

    public AtividadeExtraRepositorio(ISession session) : base(session) { }
    public IList<AtividadeExtra> Listar(string nome)
    {
        string query = "SELECT * FROM atividadesExtras ae INNER JOIN alunos a ON a.Matricula = ae.MatriculaAluno INNER JOIN endereco e ON a.IdEndereco = e.id";

        if (!string.IsNullOrEmpty(nome))
            query += $" WHERE ae.nome LIKE '%{nome}%'";


        IList<AtividadeExtra> atividadeExtras = session.Connection.Query<AtividadeExtra, Aluno, Endereco, AtividadeExtra>(
            query,
                (atividadeextra, aluno, endereco) =>
                {
                    atividadeextra.SetAluno(aluno);
                    atividadeextra.Aluno.SetEndereco(endereco);
                    return atividadeextra;
                },
                splitOn: "Matricula, id"
            ).ToList();

        return atividadeExtras;
    }
}
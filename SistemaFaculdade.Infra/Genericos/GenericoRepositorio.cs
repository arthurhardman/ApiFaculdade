using System.Transactions;
using NHibernate;
using SistemaFaculdade.Dominio.Genericos.Repositorio;

namespace SistemaFaculdade.Infra.Genericos;

public class GenericoRepositorio<T> : IGenericoRepositorio<T>
{
    protected readonly ISession session;

    public GenericoRepositorio(ISession session)
    {
        this.session = session;
    }

    public T Alterar(T objeto)
    {
        using TransactionScope scope = new TransactionScope();
        try
        {
            session.Update(objeto);
            scope.Complete();
            return objeto;
        }
        catch (Exception ex)
        {
            throw new Exception($"Está dando erro em Alterar, mensagem de erro: {ex}");
        }
    }

    public T Inserir(T objeto)
    {
        using var scope = new TransactionScope();
        try
        {
            int id = (int)session.Save(objeto);
            var obj = Recuperar(id);
            scope.Complete();
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception($"Está dando erro em inserir, mensagem de erro: {ex}");
        }
    }

    public IList<T> Listar(IQueryable<T> query)
    {
        var lista = query.ToList();
        return lista;
    }

    public T Recuperar(int id)
    {
        var objeto = session.Get<T>(id);
        return objeto;
    }

    public void Remover(T objeto)
    {
        using var scope = new TransactionScope();
        try
        {
            session.Delete(objeto);
            scope.Complete();
        }
        catch (Exception ex)
        {
            throw new Exception($"Está dando erro em Remover, mensagem de erro: {ex}");
        }
    }
}
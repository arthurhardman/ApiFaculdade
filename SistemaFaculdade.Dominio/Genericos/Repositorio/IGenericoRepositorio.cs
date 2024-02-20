using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.Genericos.Repositorio;

public interface IGenericoRepositorio<T>
{
    T Inserir(T objeto);
    void Remover(T objeto);
    T Alterar(T objeto);
    T Recuperar(int id);
    IList<T> Listar(IQueryable<T> query);
}
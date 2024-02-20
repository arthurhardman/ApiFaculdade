using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.Genericos.Repositorio;

namespace SistemaFaculdade.Dominio.AtividadesExtras.Repositorios;

public interface IAtividadeExtraRepositorio : IGenericoRepositorio<AtividadeExtra>
{
    IList<AtividadeExtra> Listar(string nome);
}
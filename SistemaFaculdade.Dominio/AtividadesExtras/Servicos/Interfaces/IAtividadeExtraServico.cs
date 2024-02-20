using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Interfaces;

public interface IAtividadeExtraServico
{
    AtividadeExtra Inserir(AtividadeExtraInserirComando atividadeExtra);
    AtividadeExtra Instanciar(AtividadeExtraInserirComando atividadeExtra);
    AtividadeExtra Atualizar(AtividadeExtraAlterarComando atividadeExtra);
    AtividadeExtra Validar(int id);
    void Excluir(int id);

}
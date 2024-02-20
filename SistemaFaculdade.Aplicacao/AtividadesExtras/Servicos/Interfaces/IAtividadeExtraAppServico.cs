using SistemaFaculdade.DataTransfer.AtividadesExtras.Requests;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Responses;

namespace SistemaFaculdade.Aplicacao.AtividadesExtras.Servicos.Interfaces;

public interface IAtividadeExtraAppServico
{
    AtividadeExtraResponse Inserir(AtividadeExtraInserirRequest atividadeExtraRequest);
    AtividadeExtraResponse Recuperar(int id);
    AtividadeExtraResponse Alterar(AtividadeExtraAlterarRequest atividadeExtraRequest);
    void Deletar(int id);
    IList<AtividadeExtraResponse> Listar(AtividadeExtraListarRequest atividadeExtraRequest);
}
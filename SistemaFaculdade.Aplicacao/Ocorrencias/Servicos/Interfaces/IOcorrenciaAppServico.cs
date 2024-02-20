using SistemaFaculdade.DataTransfer.Ocorrencias.Requests;
using SistemaFaculdade.DataTransfer.Ocorrencias.Responses;

namespace SistemaFaculdade.Aplicacao.Ocorrencias.Servicos.Interfaces;

public interface IOcorrenciaAppServico
{
    OcorrenciaResponse Inserir(OcorrenciaInserirRequest ocorrenciaRequest);
    OcorrenciaResponse Recuperar(int id);
    OcorrenciaResponse Alterar(OcorrenciaAlterarRequest ocorrenciaRequest);
    void Deletar(int id);
}
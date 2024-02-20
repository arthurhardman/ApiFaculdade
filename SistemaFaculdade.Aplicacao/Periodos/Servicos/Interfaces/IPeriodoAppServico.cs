using SistemaFaculdade.DataTransfer.Periodos.Requests;
using SistemaFaculdade.DataTransfer.Periodos.Responses;

namespace SistemaFaculdade.Aplicacao.Periodos.Servicos.Interfaces;

public interface IPeriodoAppServico
{
    PeriodosResponse Inserir(PeriodosInserirRequest periodo);
    PeriodosResponse Atualizar(PeriodosAtualizarRequest periodo);
    PeriodosResponse Recuperar(int id);
    void Excluir(int id);
}
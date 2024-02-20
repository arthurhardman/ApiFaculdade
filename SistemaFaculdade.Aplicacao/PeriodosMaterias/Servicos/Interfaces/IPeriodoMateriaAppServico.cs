using SistemaFaculdade.DataTransfer.PeriodosMaterias.Requests;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Responses;

namespace SistemaFaculdade.Aplicacao.PeriodosMaterias.Servicos.Interfaces;

public interface IPeriodoMateriaAppServico
{
    PeriodosMateriasResponse Inserir(PeriodosMateriasInserirRequest periodosMateriasInserir);
    PeriodosMateriasResponse Atualizar(PeriodosMateriasAtualizarRequest periodosMateriasAtualizar);
    void Excluir(int id);
    PeriodosMateriasResponse Recuperar(int id);
}
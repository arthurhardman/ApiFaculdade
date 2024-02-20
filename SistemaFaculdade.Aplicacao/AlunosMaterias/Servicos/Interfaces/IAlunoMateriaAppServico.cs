using SistemaFaculdade.DataTransfer.AlunosMaterias.Request;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Response;

namespace SistemaFaculdade.Aplicacao.AlunosMaterias.Servicos.Interfaces;

public interface IAlunoMateriaAppServico
{
    AlunoMateriaResponse Inserir(AlunoMateriaInserirRequest aluno);
    AlunoMateriaResponse Atualizar(AlunoMateriaAtualizarRequest aluno);
    AlunoMateriaResponse Recuperar(int id);
    void Excluir(int id);
}
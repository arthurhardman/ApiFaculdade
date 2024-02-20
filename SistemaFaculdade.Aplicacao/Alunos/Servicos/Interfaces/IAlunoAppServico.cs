using SistemaFaculdade.DataTransfer.Alunos.Requests;
using SistemaFaculdade.DataTransfer.Alunos.Responses;

namespace SistemaFaculdade.Aplicacao.Alunos.Servicos.Interfaces;

public interface IAlunoAppServico
{
    AlunoResponse Inserir(AlunoInserirRequest alunoRequest);
    AlunoResponse Recuperar(int matricula);
    AlunoResponse Alterar(AlunoAlterarRequest alunoRequest);
    void Deletar(int matricula);
    IList<AlunoResponse> Listar(AlunoListarRequest alunoRequest);
}
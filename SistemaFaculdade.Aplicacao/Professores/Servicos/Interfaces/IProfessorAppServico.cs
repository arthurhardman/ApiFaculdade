using SistemaFaculdade.DataTransfer.Professores.Requests;
using SistemaFaculdade.DataTransfer.Professores.Responses;

namespace SistemaFaculdade.Aplicacao.Professores.Servicos.Interfaces;

public interface IProfessorAppServico
{
    ProfessorResponse Inserir(ProfessorInserirRequest professorRequest);
    ProfessorResponse Recuperar(int id);
    ProfessorResponse Alterar(ProfessorAlterarRequest professorRequest);
    void Deletar(int id);
    IList<ProfessorResponse> Listar(ProfessorListarRequest professorRequest);
}
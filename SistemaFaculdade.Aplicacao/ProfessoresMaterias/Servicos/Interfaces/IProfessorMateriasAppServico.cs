using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Requests;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Responses;

namespace SistemaFaculdade.Aplicacao.ProfessoresMaterias.Servicos.Interfaces;

public interface IProfessorMateriasAppServico
{
    ProfessorMateriasResponse Inserir(ProfessorMateriasInserirRequest professorMateria);
    ProfessorMateriasResponse Atualizar(ProfessorMateriasAtualizarRequest professorMateria);
    void Excluir(int id);
    ProfessorMateriasResponse Recuperar(int id);
}
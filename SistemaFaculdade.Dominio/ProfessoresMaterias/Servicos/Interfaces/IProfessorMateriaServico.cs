using SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Interfaces;

public interface IProfessorMateriaServico
{
    ProfessorMateria Inserir(ProfessorMateriaInserirComando professorMateria);
    ProfessorMateria Atualizar(ProfessorMateriaAtualizarComando professorMateria);
    ProfessorMateria Instanciar(ProfessorMateriaInserirComando professorMateria);
    void Excluir(int id);
    ProfessorMateria Validar(int id);
}
using SistemaFaculdade.Dominio.Professores.Entidades;
using SistemaFaculdade.Dominio.Professores.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.Professores.Servicos.Interfaces;

public interface IProfessorServico
{
   Professor Inserir(ProfessorInserirComando aluno);
   Professor Instanciar(ProfessorInserirComando aluno);
   Professor Atualizar(ProfessorAlterarComando aluno);
   Professor Validar(int id);
   void Excluir(int id);
}
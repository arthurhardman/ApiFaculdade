using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;
using SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Interfaces;

public interface IAlunoMateriaServico
{
   AlunoMateria Inserir(AlunoMateriasInserirComando aluno);
   AlunoMateria Atualizar(AlunoMateriasAtualizarComando aluno);
   AlunoMateria Validar(int id);
   AlunoMateria Instanciar(AlunoMateriasInserirComando aluno);
   void Excluir(int id);
}
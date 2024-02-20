using SistemaFaculdade.Dominio.Periodos.Entidades;
using SistemaFaculdade.Dominio.Periodos.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.Periodos.Servicos.Interfaces;

public interface IPeriodoServico
{
   Periodo Inserir(PeriodoInserirComando aluno);
   Periodo Instanciar(PeriodoInserirComando aluno);
   Periodo Atualizar(PeriodoAtualizarComando aluno);
   Periodo Validar(int id);
   void Excluir(int id);
}
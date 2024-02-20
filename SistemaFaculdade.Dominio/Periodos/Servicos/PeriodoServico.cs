using SistemaFaculdade.Dominio.Periodos.Entidades;
using SistemaFaculdade.Dominio.Periodos.Repositorios;
using SistemaFaculdade.Dominio.Periodos.Servicos.Comandos;
using SistemaFaculdade.Dominio.Periodos.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.Periodos.Servicos;

public class PeriodoServico : IPeriodoServico
{
   private readonly IPeriodoRepositorio periodoRepositorio;

   public PeriodoServico(IPeriodoRepositorio periodoRepositorio)
   {
      this.periodoRepositorio = periodoRepositorio;
   }

   public Periodo Atualizar(PeriodoAtualizarComando periodo)
   {
      Periodo objeto = Validar(periodo.Id);

      objeto.SetNome(periodo.Nome);
      objeto.SetTurno(periodo.Turno);

      return periodoRepositorio.Alterar(objeto);
   }

   public void Excluir(int id)
   {
      Periodo periodo = Validar(id);
      periodoRepositorio.Remover(periodo);
   }

   public Periodo Inserir(PeriodoInserirComando periodo)
   {
      Periodo objeto = Instanciar(periodo);
      periodoRepositorio.Inserir(objeto);

      return objeto;
   }

   public Periodo Instanciar(PeriodoInserirComando periodo)
   {
      return new Periodo(periodo.Nome, periodo.Turno);
   }

   public Periodo Validar(int id)
   {
      Periodo periodo = periodoRepositorio.Recuperar(id) ?? throw new Exception("O periodo não existe");

      return periodo;
   }
}
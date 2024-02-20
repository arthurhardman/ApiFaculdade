using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;
using SistemaFaculdade.Dominio.AlunosMaterias.Repositorios;
using SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Comandos;
using SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Materias.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.AlunosMaterias.Servicos;

public class AlunoMateriaServico : IAlunoMateriaServico
{
   private readonly IAlunoMateriaRepositorio alunoMateriaRepositorio;
   private readonly IAlunoServico alunoServico;
   private readonly IMateriaServico materiaServico;

   public AlunoMateriaServico(IAlunoMateriaRepositorio alunoMateriaRepositorio, IAlunoServico alunoServico, IMateriaServico materiaServico)
   {
      this.alunoMateriaRepositorio = alunoMateriaRepositorio;
      this.alunoServico = alunoServico;
      this.materiaServico = materiaServico;
   }

   public AlunoMateria Atualizar(AlunoMateriasAtualizarComando alunoComando)
   {
      Aluno aluno = alunoServico.Validar(alunoComando.MatriculaAluno);
      Materia materia = materiaServico.Validar(alunoComando.IdMateria);
      AlunoMateria alunoMateria = Validar(alunoComando.Id);

      if (aluno.Materias.Contains(materia))
      {
         throw new Exception("Já possui essa materias para este aluno cadastrado");
      }

      alunoMateria.SetAluno(aluno);
      alunoMateria.SetMateria(materia);

      return alunoMateriaRepositorio.Alterar(alunoMateria);
   }

   public void Excluir(int id)
   {
      AlunoMateria alunoMateria = Validar(id);
      alunoMateriaRepositorio.Remover(alunoMateria);
   }

   public AlunoMateria Inserir(AlunoMateriasInserirComando aluno)
   {
      AlunoMateria alunoMateria = Instanciar(aluno);
      alunoMateriaRepositorio.Inserir(alunoMateria);

      return alunoMateria;
   }

   public AlunoMateria Instanciar(AlunoMateriasInserirComando alunoMateria)
   {
      Aluno aluno = alunoServico.Validar(alunoMateria.MatriculaAluno);
      Materia materia = materiaServico.Validar(alunoMateria.IdMateria);

      if (aluno.Materias.Contains(materia))
      {
         throw new Exception("Já possui essa materias para este aluno cadastrado");
      }

      return new AlunoMateria(aluno, materia);
   }

   public AlunoMateria Validar(int id)
   {
      if (id <= 0)
         throw new Exception("O ID não pode ser menor ou igual a 0.");

      AlunoMateria alunoMateria = alunoMateriaRepositorio.Recuperar(id) ?? throw new Exception("A parametrização não existe.");

      return alunoMateria;
   }
}
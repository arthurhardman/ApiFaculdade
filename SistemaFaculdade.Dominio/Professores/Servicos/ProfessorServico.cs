using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Professores.Entidades;
using SistemaFaculdade.Dominio.Professores.Repositorios;
using SistemaFaculdade.Dominio.Professores.Servicos.Comandos;
using SistemaFaculdade.Dominio.Professores.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.Professores.Servicos;

public class ProfessorServico : IProfessorServico
{
   private readonly IProfessorRepositorio professorRepositorio;
   private readonly IEnderecoServico enderecoServico;

   public ProfessorServico(IProfessorRepositorio professorRepositorio, IEnderecoServico enderecoServico)
   {
      this.professorRepositorio = professorRepositorio;
      this.enderecoServico = enderecoServico;
   }

   public Professor Atualizar(ProfessorAlterarComando professor)
   {
      Professor professorExistente = Validar(professor.Id);

      professorExistente.SetNome(professor.Nome);
      professorExistente.SetEmail(professor.Email);
      professorExistente.SetSenha(professor.Senha);
      professorExistente.SetCep(professor.Cep);
      professorExistente.SetNumero(professor.Numero);
      professorExistente.SetAdicional(professor.Adicional);

      Endereco endereco = enderecoServico.Validar(professor.Cep);
      professorExistente.SetEndereco(endereco);

      return professorRepositorio.Alterar(professorExistente);
   }

   public void Excluir(int id)
   {
      Professor professor = Validar(id);
      professorRepositorio.Remover(professor);
   }

   public Professor Inserir(ProfessorInserirComando professor)
   {
      Professor professores = Instanciar(professor);

      return professorRepositorio.Inserir(professores);
   }

   public Professor Instanciar(ProfessorInserirComando comando)
   {
      Endereco endereco = enderecoServico.Validar(comando.Cep);

      return new Professor(comando.Nome, comando.Email, comando.Senha, endereco, comando.Cep,
      comando.Numero, comando.Adicional);
   }

   public Professor Validar(int id)
   {
      Professor professor = professorRepositorio.Recuperar(id) ?? throw new Exception("Professor inexistente");

      return professor;
   }
}
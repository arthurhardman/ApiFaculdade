using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Repositorios;
using SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.Alunos.Servicos;

public class AlunoServico : IAlunoServico
{
    private readonly IAlunoRepositorio alunoRepositorio;
    private readonly IEnderecoServico enderecoServico;

    public AlunoServico(IAlunoRepositorio alunoRepositorio, IEnderecoServico enderecoServico)
    {
        this.alunoRepositorio = alunoRepositorio;
        this.enderecoServico = enderecoServico;
    }

    public Aluno Atualizar(Aluno aluno)
    {
        Aluno alunoExistente = Validar(aluno.Matricula);

        alunoExistente.SetNome(aluno.Nome);
        alunoExistente.SetEmail(aluno.Email);
        alunoExistente.SetSenha(aluno.Senha);
        alunoExistente.SetCep(aluno.Cep);
        alunoExistente.SetNumero(aluno.Numero);
        alunoExistente.SetAdicional(aluno.Adicional);

        return alunoRepositorio.Alterar(alunoExistente);
    }

    public void Excluir(int id)
    {
        Aluno aluno = Validar(id);
        alunoRepositorio.Remover(aluno);
    }

    public Aluno Inserir(Aluno aluno)
    {
        Aluno alunos = Instanciar(aluno);

        return alunoRepositorio.Inserir(alunos);
    }

    public Aluno Instanciar(Aluno aluno)
    {
        Endereco endereco = enderecoServico.Validar(aluno.Cep);
        return new Aluno(aluno.Nome, aluno.Email, aluno.Senha, aluno.Cep,
        aluno.Numero, aluno.Adicional, endereco);
    }

    public Aluno Validar(int matricula)
    {
        Aluno aluno = alunoRepositorio.Recuperar(matricula) ?? throw new Exception("Aluno inexistente");

        return aluno;
    }
}
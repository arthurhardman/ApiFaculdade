using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Repositorios;
using SistemaFaculdade.Dominio.Alunos.Servicos;
using SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;
using Xunit;

namespace SistemaFaculdade.Dominio.Testes.Alunos.Servicos;

public class AlunosServicosTestes
{
    private readonly IAlunoServico sut;
    private readonly Aluno alunoValido;
    private readonly IAlunoRepositorio alunoRepositorio;
    private readonly IEnderecoServico enderecoServico;

    public AlunosServicosTestes()
    {
        alunoValido = Builder<Aluno>.CreateNew().Build();
        alunoRepositorio = Substitute.For<IAlunoRepositorio>();
        enderecoServico = Substitute.For<IEnderecoServico>();
        sut = new AlunoServico(alunoRepositorio, enderecoServico);
    }

    public class ValidarMetodo : AlunosServicosTestes
    {
        [Fact]
        public void QuandoAlunoNaoEncontrado_Espero_Excecao()
        {
            alunoRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
            sut.Invoking(x => x.Validar(3)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoAlunoForValido_Espero_AlunoValido()
        {
            alunoRepositorio.Recuperar(Arg.Any<int>()).Returns(x => alunoValido);
            Aluno aluno = sut.Validar(1);
            aluno.Should().BeSameAs(alunoValido);
        }
    }

    public class InserirMetodo : AlunosServicosTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuanoAlunoInvalidoAoInserir_Espero_Excecao(Aluno aluno)
        {
            alunoRepositorio.Inserir(Arg.Any<Aluno>()).Returns(x => null);
            sut.Invoking(x => x.Inserir(aluno)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoAlunoForValidoAoInserir_Espero_PropriedadePreenchida()
        {
            alunoRepositorio.Inserir(Arg.Any<Aluno>()).Returns(x => alunoValido);
            Aluno aluno = sut.Inserir(alunoValido);
            aluno.Should().Be(alunoValido);
        }
    }

    public class DeletarMetodo : AlunosServicosTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoAlunoInvalidoAoDeletar_Espero_Excecao(Aluno aluno)
        {
            alunoRepositorio.Remover(Arg.Any<Aluno>());
            sut.Invoking(x => x.Excluir(aluno.Matricula)).Should().Throw<Exception>();

        }
    }
}


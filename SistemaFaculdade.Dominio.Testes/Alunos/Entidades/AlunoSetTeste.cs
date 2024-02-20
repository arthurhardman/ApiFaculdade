using SistemaFaculdade.Dominio.Alunos.Entidades;
using FizzWare.NBuilder;
using Xunit;
using FluentAssertions;

namespace SistemaFaculdade.Dominio.Testes.Alunos.Entidades;

public class AlunoTestes
{
    private readonly Aluno sut;

    public AlunoTestes()
    {
        sut = Builder<Aluno>.CreateNew().Build();
    }

    public class SetNomeTestes : AlunoTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoNomeDoAlunoForNulo_EsperoExcecao(string nome)
        {
            sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoNomeDoAlunoForMaiorQue50_EsperoExcecao()
        {
            sut.Invoking(x => x.SetNome(new string('*', 51))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoNomeForValido_EsperoPropriedadePreenchida()
        {
            string nome = "Arthur";
            sut.SetNome(nome);
            sut.Nome.Length.Should().BeLessThan(51);
            sut.Nome.Should().NotBeNull();
            sut.Nome.Should().Be(nome);
        }
    }

    public class SetEmailTestes : AlunoTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoEmailDoAlunoForNulo_EsperoExcecao(string email)
        {
            sut.Invoking(x => x.SetEmail(email)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoEmailDoAlunoForMaiorQue100_EsperoExcecao()
        {
            sut.Invoking(x => x.SetEmail(new string('*', 101))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoEmailForValido_EsperoPropriedadePreenchida()
        {
            string email = "arthur.augusto@gmail.com";
            sut.SetEmail(email);
            sut.Email.Length.Should().BeLessThan(101);
            sut.Email.Should().NotBeNull();
            sut.Email.Should().Be(email);
        }
    }

    public class SetSenhaTestes : AlunoTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoSenhaDoAlunoForNulo_EsperoExcecao(string senha)
        {
            sut.Invoking(x => x.SetSenha(senha)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoSenhaDoAlunoForMaiorQue12_EsperoExcecao()
        {
            sut.Invoking(x => x.SetSenha(new string('*', 13))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoSenhaForValido_EsperoPropriedadePreenchida()
        {
            string senha = "123456";
            sut.SetSenha(senha);
            sut.Senha.Length.Should().BeLessThan(13);
            sut.Senha.Should().NotBeNull();
            sut.Senha.Should().Be(senha);
        }
    }

    public class SetCepTestes : AlunoTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoCepDoAlunoForNulo_EsperoExcecao(string cep)
        {
            sut.Invoking(x => x.SetCep(cep)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoCepDoAlunoForMaiorQue8_EsperoExcecao()
        {
            sut.Invoking(x => x.SetCep(new string('*', 9))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoCepForValido_EsperoPropriedadePreenchida()
        {
            string cep = "29101850";
            sut.SetCep(cep);
            sut.Cep.Length.Should().BeLessThan(9);
            sut.Cep.Should().NotBeNull();
            sut.Cep.Should().Be(cep);
        }
    }

    public class SetNumeroTestes : AlunoTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoNumeroDoAlunoForNulo_EsperoExcecao(string numero)
        {
            sut.Invoking(x => x.SetNumero(numero)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoNumeroDoAlunoForMaiorQue8_EsperoExcecao()
        {
            sut.Invoking(x => x.SetNumero(new string('*', 9))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoNumeroForValido_EsperoPropriedadePreenchida()
        {
            string numero = "29101850";
            sut.SetNumero(numero);
            sut.Numero.Length.Should().BeLessThan(9);
            sut.Numero.Should().NotBeNull();
            sut.Numero.Should().Be(numero);
        }
    }

    public class SetAdicionalTestes : AlunoTestes
    {
        [Theory]
        [InlineData(null)]
        public void QuandoAdicionalDoAlunoForNulo_EsperoExcecao(string adicional)
        {
            sut.Invoking(x => x.SetAdicional(adicional)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoAdicionalDoAlunoForMaiorQue100_EsperoExcecao()
        {
            sut.Invoking(x => x.SetAdicional(new string('*', 101))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoAdicionalForValido_EsperoPropriedadePreenchida()
        {
            string adicional = new('*', 100);
            sut.SetAdicional(adicional);
            sut.Adicional.Length.Should().BeLessThan(101);
            sut.Adicional.Should().NotBeNull();
            sut.Adicional.Should().Be(adicional);
        }
    }
}
using FizzWare.NBuilder;
using FluentAssertions;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using Xunit;

namespace SistemaFaculdade.Dominio.Testes.AtividadesExtras.Entidades;

public class AtividadeExtraTeste
{
    private readonly AtividadeExtra sut;

    public AtividadeExtraTeste()
    {
        sut = Builder<AtividadeExtra>.CreateNew().Build();
    }

    public class SetNomeTestes : AtividadeExtraTeste
    {
        [Theory]
        [InlineData(null)]
        public void QuandoNomeDaAtividadeExtraForNulo_EsperoExcecao(string nome)
        {
            sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoNomeDaAtividadeExtraForMaiorQue100_EsperoExcecao()
        {
            sut.Invoking(x => x.SetNome(new string('*', 101))).Should().Throw<Exception>();
        }

        [Fact]
        public void QuandoNomeForValido_EsperoPropriedadePreenchida()
        {
            string nome = "Atividade Extra";
            sut.SetNome(nome);
            sut.Nome.Length.Should().BeLessThan(101);
            sut.Nome.Should().NotBeNull();
            sut.Nome.Should().Be(nome);
        }
    }
}
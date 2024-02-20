using System.Text.Json;
using NHibernate;
using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Repositorios;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Comandos;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Enderecos.Repositorios;

public class EnderecoRepositorio : GenericoRepositorio<Endereco>, IEnderecoRepositorio
{

    public EnderecoRepositorio(ISession session) : base(session)
    {
    }

    public Endereco ValidarCep(string cep)
    {
        var endereco = session.Query<Endereco>().FirstOrDefault(e => e.Cep == cep);

        return endereco;
    }

    public async Task<Endereco> ObterDadosDaApiAsync(string cep)
    {
        using HttpClient httpClient = new HttpClient();

        string jsonUrl = $"https://viacep.com.br/ws/{cep}/json/";

        try
        {
            string resposta = await httpClient.GetStringAsync(jsonUrl);
            var enderecoComando = JsonSerializer.Deserialize<EnderecoComando>(resposta);
            if (enderecoComando.Cep is null)
            {
                throw new Exception("Esse endereço não existe");
            }

            Endereco endereco = new Endereco(
            enderecoComando.Cep,
            enderecoComando.Logradouro,
            enderecoComando.Bairro,
            enderecoComando.Localidade,
            enderecoComando.Uf
            );

            return endereco;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Erro na requisição HTTP: {ex.Message}");
        }
    }
}
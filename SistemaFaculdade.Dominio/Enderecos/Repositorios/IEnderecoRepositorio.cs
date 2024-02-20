using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Comandos;
using SistemaFaculdade.Dominio.Genericos.Repositorio;

namespace SistemaFaculdade.Dominio.Enderecos.Repositorios;

public interface IEnderecoRepositorio : IGenericoRepositorio<Endereco>
{
   Endereco ValidarCep(string cep);
   public Task<Endereco> ObterDadosDaApiAsync(string cep);
}
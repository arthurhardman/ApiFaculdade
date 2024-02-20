using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;

public interface IEnderecoServico
{
    public Endereco Inserir(Endereco enderecoComando);
    public Endereco Validar(string cep);
}
using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Repositorios;
using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Repositorios;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.Enderecos.Servicos;

public class EnderecoServico : IEnderecoServico
{
    private readonly IEnderecoRepositorio enderecoRepositorio;

    public EnderecoServico(IEnderecoRepositorio enderecoRepositorio)
    {
        this.enderecoRepositorio = enderecoRepositorio;
    }

    public Endereco Inserir(Endereco comando)
    {
        Endereco endereco = new(comando.Cep, comando.Logradouro, comando.Bairro, comando.Localidade, comando.Uf);
        enderecoRepositorio.Inserir(endereco);

        return endereco;
    }

    public Endereco Validar(string cep)
    {
        Endereco enderecoExiste = enderecoRepositorio.ValidarCep(cep);
        if (enderecoExiste != null)
        {
            return enderecoExiste;
        }
        else
        {
            return Inserir(enderecoRepositorio.ObterDadosDaApiAsync(cep).Result);
        }
    }
}
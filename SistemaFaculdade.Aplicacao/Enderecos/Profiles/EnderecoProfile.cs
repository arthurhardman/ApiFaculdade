using AutoMapper;
using SistemaFaculdade.DataTransfer.Enderecos.Responses;
using SistemaFaculdade.Dominio.Enderecos.Entidades;

namespace SistemaFaculdade.Aplicacao.Enderecos.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<Endereco, EnderecoResponse>();
    }
}
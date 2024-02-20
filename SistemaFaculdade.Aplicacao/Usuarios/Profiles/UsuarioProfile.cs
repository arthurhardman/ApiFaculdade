using AutoMapper;
using SistemaFaculdade.DataTransfer.Usuarios.Requests;
using SistemaFaculdade.DataTransfer.Usuarios.Responses;
using SistemaFaculdade.Dominio.Usuarios.Entidades;
using SistemaFaculdade.Dominio.Usuarios.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.Usuarios.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioAtualizarRequest, UsuarioAtualizarComando>();
        CreateMap<UsuarioInserirRequest, UsuarioInserirComando>();
        CreateMap<Usuario, UsuarioResponse>();
    }
}
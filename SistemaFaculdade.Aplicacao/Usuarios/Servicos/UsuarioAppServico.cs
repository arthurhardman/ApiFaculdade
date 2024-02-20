using AutoMapper;
using SistemaFaculdade.Aplicacao.Usuarios.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Usuarios.Requests;
using SistemaFaculdade.DataTransfer.Usuarios.Responses;
using SistemaFaculdade.Dominio.Usuarios.Entidades;
using SistemaFaculdade.Dominio.Usuarios.Servicos.Comandos;
using SistemaFaculdade.Dominio.Usuarios.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.Usuarios.Servicos;

public class UsuarioAppServico : IUsuarioAppServico
{
    private readonly IUsuarioServico usuarioServico;
    private readonly IMapper mapper;

    public UsuarioAppServico(IUsuarioServico usuarioServico, IMapper mapper)
    {
        this.usuarioServico = usuarioServico;
        this.mapper = mapper;
    }

    public UsuarioResponse Atualizar(UsuarioAtualizarRequest request)
    {
        UsuarioAtualizarComando comando = mapper.Map<UsuarioAtualizarComando>(request);

        Usuario usuario = usuarioServico.Atualizar(comando);

        return mapper.Map<UsuarioResponse>(usuario);
    }

    public UsuarioResponse Inserir(UsuarioInserirRequest request)
    {
        UsuarioInserirComando comando = mapper.Map<UsuarioInserirComando>(request);

        Usuario usuario = usuarioServico.Inserir(comando);

        return mapper.Map<UsuarioResponse>(usuario);
    }

    public UsuarioResponse Recuperar(int id)
    {
        Usuario usuario = usuarioServico.Validar(id);

        return mapper.Map<UsuarioResponse>(usuario);
    }
}
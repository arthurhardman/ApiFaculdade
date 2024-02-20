using SistemaFaculdade.Dominio.Usuarios.Entidades;
using SistemaFaculdade.Dominio.Usuarios.Repositorios;
using SistemaFaculdade.Dominio.Usuarios.Servicos.Comandos;
using SistemaFaculdade.Dominio.Usuarios.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.Usuarios.Servicos;

public class UsuarioServico : IUsuarioServico
{
    private readonly IUsuariosRepositorio usuariosRepositorio;

    public UsuarioServico(IUsuariosRepositorio usuariosRepositorio)
    {
        this.usuariosRepositorio = usuariosRepositorio;
    }

    public Usuario Atualizar(UsuarioAtualizarComando comando)
    {
        Usuario usuario = Validar(comando.Id);

        usuario.SetNome(comando.Nome);
        usuario.SetSenha(comando.Senha);
        usuario.SetTipoUsuario(comando.TipoUsuario);
        usuario.SetAtivoInativo(comando.AtivoInativo);

        return usuariosRepositorio.Alterar(usuario);
    }

    public Usuario Inserir(UsuarioInserirComando comando)
    {
        Usuario usuario = Instanciar(comando);

        return usuariosRepositorio.Inserir(usuario);
    }

    public Usuario Instanciar(UsuarioInserirComando comando)
    {
        return new Usuario(comando.Nome, comando.Senha, comando.TipoUsuario, comando.AtivoInativo);
    }

    public Usuario Validar(int id)
    {
        Usuario usuario = usuariosRepositorio.Recuperar(id) ?? throw new Exception("Usuario não existe");

        return usuario;
    }
}
using SistemaFaculdade.Dominio.Usuarios.Entidades;
using SistemaFaculdade.Dominio.Usuarios.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.Usuarios.Servicos.Interfaces;

public interface IUsuarioServico
{
    Usuario Inserir(UsuarioInserirComando comando);
    Usuario Instanciar(UsuarioInserirComando comando);
    Usuario Atualizar(UsuarioAtualizarComando comando);
    Usuario Validar(int id);
}
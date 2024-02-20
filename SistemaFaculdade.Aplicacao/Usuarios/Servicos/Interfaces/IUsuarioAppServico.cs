using SistemaFaculdade.DataTransfer.Usuarios.Requests;
using SistemaFaculdade.DataTransfer.Usuarios.Responses;
using SistemaFaculdade.Dominio.Usuarios.Entidades;

namespace SistemaFaculdade.Aplicacao.Usuarios.Servicos.Interfaces;

public interface IUsuarioAppServico
{
    UsuarioResponse Inserir(UsuarioInserirRequest request);
    UsuarioResponse Atualizar(UsuarioAtualizarRequest request);
    UsuarioResponse Recuperar(int id);
}
using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.Usuarios.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Usuarios.Requests;
using SistemaFaculdade.DataTransfer.Usuarios.Responses;

namespace SistemaFaculdade.Api.Controllers.Usuarios;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioAppServico usuarioAppServico;

    public UsuarioController(IUsuarioAppServico usuarioAppServico)
    {
        this.usuarioAppServico = usuarioAppServico;
    }

    /// <summary>
    /// Recupera um usuario por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<UsuarioResponse> Recuperar(int id)
    {
        UsuarioResponse response = usuarioAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um usuario
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<UsuarioResponse> Atualizar([FromBody] UsuarioAtualizarRequest request)
    {
        UsuarioResponse response = usuarioAppServico.Atualizar(request);
        return Ok(response);
    }

    /// <summary>
    /// Insere um usuario
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<UsuarioResponse> Inserir([FromBody] UsuarioInserirRequest request)
    {
        UsuarioResponse response = usuarioAppServico.Inserir(request);
        return Ok(response);
    }
}
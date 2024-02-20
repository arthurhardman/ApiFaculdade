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

    [HttpGet("{id}")]
    public ActionResult<UsuarioResponse> Recuperar(int id)
    {
        UsuarioResponse response = usuarioAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<UsuarioResponse> Atualizar([FromBody] UsuarioAtualizarRequest request)
    {
        UsuarioResponse response = usuarioAppServico.Atualizar(request);
        return Ok(response);
    }

    [HttpPost]
    public ActionResult<UsuarioResponse> Inserir([FromBody] UsuarioInserirRequest request)
    {
        UsuarioResponse response = usuarioAppServico.Inserir(request);
        return Ok(response);
    }
}
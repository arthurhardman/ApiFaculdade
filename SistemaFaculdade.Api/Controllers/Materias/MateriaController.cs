using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.Materias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Materias.Requests;
using SistemaFaculdade.DataTransfer.Materias.Responses;

namespace SistemaFaculdade.Api.Controllers.Materias;

[ApiController]
[Route("api/[controller]")]
public class MateriaController : ControllerBase
{
    private readonly IMateriaAppServico materiaAppServico;
    public MateriaController(IMateriaAppServico materiaAppServico)
    {
        this.materiaAppServico = materiaAppServico;
    }

    [HttpPost]
    public ActionResult<MateriaResponse> Inserir([FromBody] MateriaInserirRequest materiaInserirRequest)
    {
        var response = materiaAppServico.Inserir(materiaInserirRequest);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<MateriaResponse> Recuperar(int id)
    {
        MateriaResponse response = materiaAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<MateriaResponse> Alterar(MateriaAlterarRequest materiaAlterarRequest)
    {
        var response = materiaAppServico.Alterar(materiaAlterarRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        materiaAppServico.Deletar(id);

        return Ok();
    }

    [HttpGet]
    public ActionResult<IList<MateriaResponse>> Listar([FromQuery] MateriaListarRequest materiaListarRequest)
    {
        IList<MateriaResponse> response = materiaAppServico.Listar(materiaListarRequest);
        return Ok(response);
    }
}
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

    /// <summary>
    /// Insere uma materia
    /// </summary>
    /// <param name="materiaInserirRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<MateriaResponse> Inserir([FromBody] MateriaInserirRequest materiaInserirRequest)
    {
        var response = materiaAppServico.Inserir(materiaInserirRequest);
        return Ok(response);
    }

    /// <summary>
    /// Recupera uma materia por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<MateriaResponse> Recuperar(int id)
    {
        MateriaResponse response = materiaAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Altera uma materia
    /// </summary>
    /// <param name="materiaAlterarRequest"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<MateriaResponse> Alterar(MateriaAlterarRequest materiaAlterarRequest)
    {
        var response = materiaAppServico.Alterar(materiaAlterarRequest);
        return Ok(response);
    }

    /// <summary>
    /// Recupera uma materia por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        materiaAppServico.Deletar(id);

        return Ok();
    }

    /// <summary>
    /// Recupera uma lista de materias
    /// </summary>
    /// <param name="materiaListarRequest"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<MateriaResponse>> Listar([FromQuery] MateriaListarRequest materiaListarRequest)
    {
        IList<MateriaResponse> response = materiaAppServico.Listar(materiaListarRequest);
        return Ok(response);
    }
}
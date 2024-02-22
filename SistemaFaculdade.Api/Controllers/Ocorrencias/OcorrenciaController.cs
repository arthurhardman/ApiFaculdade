using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.Ocorrencias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Ocorrencias.Requests;
using SistemaFaculdade.DataTransfer.Ocorrencias.Responses;

namespace SistemaFaculdade.Api.Controllers.Ocorrencias;

[ApiController]
[Route("api/[controller]")]
public class OcorrenciaController : ControllerBase
{
    private readonly IOcorrenciaAppServico ocorrenciaAppServico;

    public OcorrenciaController(IOcorrenciaAppServico ocorrenciaAppServico)
    {
        this.ocorrenciaAppServico = ocorrenciaAppServico;
    }

    /// <summary>
    /// Insere uma ocorrencia
    /// </summary>
    /// <param name="ocorrenciaInserirRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<OcorrenciaResponse> Inserir([FromBody] OcorrenciaInserirRequest ocorrenciaInserirRequest)
    {
        var response = ocorrenciaAppServico.Inserir(ocorrenciaInserirRequest);
        return Ok(response);
    }

    /// <summary>
    /// Recupera uma ocorrencia por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<OcorrenciaResponse> Recuperar(int id)
    {
        OcorrenciaResponse response = ocorrenciaAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Altera uma ocorrencia
    /// </summary>
    /// <param name="ocorrenciaAlterarRequest"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<OcorrenciaResponse> Alterar(OcorrenciaAlterarRequest ocorrenciaAlterarRequest)
    {
        OcorrenciaResponse response = ocorrenciaAppServico.Alterar(ocorrenciaAlterarRequest);
        return Ok(response);
    }


    /// <summary>
    /// Deleta uma ocorrencia
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        ocorrenciaAppServico.Deletar(id);

        return Ok();
    }
}
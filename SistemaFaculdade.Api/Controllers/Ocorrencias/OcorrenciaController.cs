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

    [HttpPost]
    public ActionResult<OcorrenciaResponse> Inserir([FromBody] OcorrenciaInserirRequest ocorrenciaInserirRequest)
    {
        var response = ocorrenciaAppServico.Inserir(ocorrenciaInserirRequest);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<OcorrenciaResponse> Recuperar(int id)
    {
        OcorrenciaResponse response = ocorrenciaAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<OcorrenciaResponse> Alterar(OcorrenciaAlterarRequest ocorrenciaAlterarRequest)
    {
        OcorrenciaResponse response = ocorrenciaAppServico.Alterar(ocorrenciaAlterarRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        ocorrenciaAppServico.Deletar(id);

        return Ok();
    }
}
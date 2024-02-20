using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.AtividadesExtras.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Requests;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Responses;

namespace SistemaFaculdade.Api.Controllers.AtividadesExtras;

[ApiController]
[Route("api/[controller]")]
public class AtividadesExtrasController : ControllerBase
{
    private readonly IAtividadeExtraAppServico atividadeExtraAppServico;
    public AtividadesExtrasController(IAtividadeExtraAppServico atividadeExtraAppServico)
    {
        this.atividadeExtraAppServico = atividadeExtraAppServico;
    }

    [HttpPost]
    public ActionResult<AtividadeExtraResponse> Inserir([FromBody] AtividadeExtraInserirRequest atividadeExtraInserirRequest)
    {
        var response = atividadeExtraAppServico.Inserir(atividadeExtraInserirRequest);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<AtividadeExtraResponse> Recuperar(int id)
    {
        AtividadeExtraResponse response = atividadeExtraAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<AtividadeExtraResponse> Alterar(AtividadeExtraAlterarRequest atividadeExtraAlterarRequest)
    {
        var response = atividadeExtraAppServico.Alterar(atividadeExtraAlterarRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        atividadeExtraAppServico.Deletar(id);

        return Ok();
    }

    [HttpGet]
    public ActionResult<IList<AtividadeExtraResponse>> Listar([FromQuery] AtividadeExtraListarRequest atividadeExtraListarRequest)
    {
        IList<AtividadeExtraResponse> response = atividadeExtraAppServico.Listar(atividadeExtraListarRequest);
        return Ok(response);
    }
}
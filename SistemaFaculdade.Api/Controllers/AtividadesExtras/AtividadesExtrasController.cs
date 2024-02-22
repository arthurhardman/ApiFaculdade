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

    /// <summary>
    /// Insere uma atividade extra
    /// </summary>
    /// <param name="atividadeExtraInserirRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<AtividadeExtraResponse> Inserir([FromBody] AtividadeExtraInserirRequest atividadeExtraInserirRequest)
    {
        var response = atividadeExtraAppServico.Inserir(atividadeExtraInserirRequest);
        return Ok(response);
    }

    /// <summary>
    /// Recupera uma atividade extra por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<AtividadeExtraResponse> Recuperar(int id)
    {
        AtividadeExtraResponse response = atividadeExtraAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza uma atividade extra
    /// </summary>
    /// <param name="atividadeExtraAlterarRequest"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<AtividadeExtraResponse> Alterar(AtividadeExtraAlterarRequest atividadeExtraAlterarRequest)
    {
        var response = atividadeExtraAppServico.Alterar(atividadeExtraAlterarRequest);
        return Ok(response);
    }

    /// <summary>
    /// Deleta uma atividade extra
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        atividadeExtraAppServico.Deletar(id);

        return Ok();
    }

    /// <summary>
    /// Lista as atividades extras
    /// </summary>
    /// <param name="atividadeExtraListarRequest"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<AtividadeExtraResponse>> Listar([FromQuery] AtividadeExtraListarRequest atividadeExtraListarRequest)
    {
        IList<AtividadeExtraResponse> response = atividadeExtraAppServico.Listar(atividadeExtraListarRequest);
        return Ok(response);
    }
}
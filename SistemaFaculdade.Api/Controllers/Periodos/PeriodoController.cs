using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.Periodos.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Periodos.Requests;
using SistemaFaculdade.DataTransfer.Periodos.Responses;

namespace SistemaFaculdade.Api.Controllers.Periodos;

[ApiController]
[Route("api/[controller]")]
public class PeriodoController : ControllerBase
{
    private readonly IPeriodoAppServico periodoAppServico;

    public PeriodoController(IPeriodoAppServico periodoAppServico)
    {
        this.periodoAppServico = periodoAppServico;
    }

    [HttpPost]
    public ActionResult<PeriodosResponse> Inserir(PeriodosInserirRequest periodoInserirRequest)
    {
        PeriodosResponse response = periodoAppServico.Inserir(periodoInserirRequest);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<PeriodosResponse> Recuperar(int id)
    {
        PeriodosResponse response = periodoAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<PeriodosResponse> Atualizar(PeriodosAtualizarRequest periodoAtualizarRequest)
    {
        PeriodosResponse response = periodoAppServico.Atualizar(periodoAtualizarRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        periodoAppServico.Excluir(id);

        return Ok();
    }
}
using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.PeriodosMaterias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Requests;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Responses;

namespace SistemaFaculdade.Api.Controllers.PeriodosMaterias;

[ApiController]
[Route("api/[controller]")]
public class PeriodoMateriaController : ControllerBase
{
    private readonly IPeriodoMateriaAppServico periodoMateriaAppServico;

    public PeriodoMateriaController(IPeriodoMateriaAppServico periodoMateriaAppServico)
    {
        this.periodoMateriaAppServico = periodoMateriaAppServico;
    }

    /// <summary>
    /// Insere um Periodo com Materia
    /// </summary>
    /// <param name="periodosMateriasInserir"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<PeriodosMateriasResponse> Inserir(PeriodosMateriasInserirRequest periodosMateriasInserir)
    {
        PeriodosMateriasResponse response = periodoMateriaAppServico.Inserir(periodosMateriasInserir);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um Periodo com Materia por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PeriodosMateriasResponse> Recuperar(int id)
    {
        PeriodosMateriasResponse response = periodoMateriaAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Periodo com Materia
    /// </summary>
    /// <param name="periodosMateriasAtualizar"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<PeriodosMateriasResponse> Alterar(PeriodosMateriasAtualizarRequest periodosMateriasAtualizar)
    {
        PeriodosMateriasResponse response = periodoMateriaAppServico.Atualizar(periodosMateriasAtualizar);
        return Ok(response);
    }

    /// <summary>
    /// Deleta um Periodo com Materia
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        periodoMateriaAppServico.Excluir(id);
        return Ok();
    }
}
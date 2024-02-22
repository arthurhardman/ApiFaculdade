using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.ProfessoresMaterias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Requests;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Responses;

namespace SistemaFaculdade.Api.Controllers.ProfessoresMaterias;

[ApiController]
[Route("api/[controller]")]
public class ProfessorMateriasController : ControllerBase
{
    private readonly IProfessorMateriasAppServico professorMateriasAppServico;

    public ProfessorMateriasController(IProfessorMateriasAppServico professorMateriasAppServico)
    {
        this.professorMateriasAppServico = professorMateriasAppServico;
    }

    /// <summary>
    /// Insere um professor com materia
    /// </summary>
    /// <param name="professorMateriasInserir"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<ProfessorMateriasResponse> Inserir(ProfessorMateriasInserirRequest professorMateriasInserir)
    {
        ProfessorMateriasResponse response = professorMateriasAppServico.Inserir(professorMateriasInserir);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um professor com materia por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ProfessorMateriasResponse> Recuperar(int id)
    {
        ProfessorMateriasResponse response = professorMateriasAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um professor com materia
    /// </summary>
    /// <param name="professorMateriasAtualizar"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<ProfessorMateriasResponse> Alterar(ProfessorMateriasAtualizarRequest professorMateriasAtualizar)
    {
        ProfessorMateriasResponse response = professorMateriasAppServico.Atualizar(professorMateriasAtualizar);
        return Ok(response);
    }

    /// <summary>
    /// Deleta um professor com materia
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        professorMateriasAppServico.Excluir(id);
        return Ok();
    }
}
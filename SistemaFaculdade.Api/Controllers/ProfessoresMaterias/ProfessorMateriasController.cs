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

    [HttpPost]
    public ActionResult<ProfessorMateriasResponse> Inserir(ProfessorMateriasInserirRequest professorMateriasInserir)
    {
        ProfessorMateriasResponse response = professorMateriasAppServico.Inserir(professorMateriasInserir);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<ProfessorMateriasResponse> Recuperar(int id)
    {
        ProfessorMateriasResponse response = professorMateriasAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<ProfessorMateriasResponse> Alterar(ProfessorMateriasAtualizarRequest professorMateriasAtualizar)
    {
        ProfessorMateriasResponse response = professorMateriasAppServico.Atualizar(professorMateriasAtualizar);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        professorMateriasAppServico.Excluir(id);
        return Ok();
    }
}
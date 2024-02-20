using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.Professores.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Professores.Requests;
using SistemaFaculdade.DataTransfer.Professores.Responses;

namespace SistemaFaculdade.Api.Controllers.Professores;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorAppServico professorAppServico;

    public ProfessorController(IProfessorAppServico professorAppServico)
    {
        this.professorAppServico = professorAppServico;
    }

    [HttpPost]
    public ActionResult<ProfessorResponse> Inserir(ProfessorInserirRequest professorInserirRequest)
    {
        ProfessorResponse response = professorAppServico.Inserir(professorInserirRequest);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<ProfessorResponse> Recuperar(int id)
    {
        ProfessorResponse response = professorAppServico.Recuperar(id);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<ProfessorResponse> Alterar(ProfessorAlterarRequest professorAlterarRequest)
    {
        ProfessorResponse response = professorAppServico.Alterar(professorAlterarRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        professorAppServico.Deletar(id);

        return Ok();
    }

    [HttpGet]
    public ActionResult<IList<ProfessorResponse>> Listar([FromQuery] ProfessorListarRequest professorListarRequest)
    {
        IList<ProfessorResponse> response = professorAppServico.Listar(professorListarRequest);
        return Ok(response);
    }
}
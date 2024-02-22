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

    /// <summary>
    /// Insere um professor
    /// </summary>
    /// <param name="professorInserirRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<ProfessorResponse> Inserir(ProfessorInserirRequest professorInserirRequest)
    {
        ProfessorResponse response = professorAppServico.Inserir(professorInserirRequest);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um professor por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ProfessorResponse> Recuperar(int id)
    {
        ProfessorResponse response = professorAppServico.Recuperar(id);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um professor
    /// </summary>
    /// <param name="professorAlterarRequest"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<ProfessorResponse> Alterar(ProfessorAlterarRequest professorAlterarRequest)
    {
        ProfessorResponse response = professorAppServico.Alterar(professorAlterarRequest);
        return Ok(response);
    }

    /// <summary>
    /// Deleta um professor
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(int id)
    {
        professorAppServico.Deletar(id);

        return Ok();
    }

    /// <summary>
    /// Recupera uma lista de professores
    /// </summary>
    /// <param name="professorListarRequest"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<ProfessorResponse>> Listar([FromQuery] ProfessorListarRequest professorListarRequest)
    {
        IList<ProfessorResponse> response = professorAppServico.Listar(professorListarRequest);
        return Ok(response);
    }
}
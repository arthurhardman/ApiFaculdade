using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.Alunos.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Alunos.Requests;
using SistemaFaculdade.DataTransfer.Alunos.Responses;

namespace SistemaFaculdade.Api.Controllers.Alunos;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoAppServico alunoAppServico;

    public AlunosController(IAlunoAppServico alunoAppServico)
    {
        this.alunoAppServico = alunoAppServico;
    }

    /// <summary>
    /// Insere um Aluno
    /// </summary>
    /// <param name="alunoInserirRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<AlunoResponse> Inserir(AlunoInserirRequest alunoInserirRequest)
    {
        AlunoResponse response = alunoAppServico.Inserir(alunoInserirRequest);
        return Ok(response);
    }

    /// <summary>
    /// Recupera um Aluno por ID
    /// </summary>
    /// <param name="matricula"></param>
    /// <returns></returns>
    [HttpGet("{matricula}")]
    public ActionResult<AlunoResponse> Recuperar(int matricula)
    {
        AlunoResponse response = alunoAppServico.Recuperar(matricula);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um Aluno
    /// </summary>
    /// <param name="alunoAlterarRequest"></param>
    /// <returns></returns>
    [HttpPut]
    public ActionResult<AlunoResponse> Alterar(AlunoAlterarRequest alunoAlterarRequest)
    {
        AlunoResponse response = alunoAppServico.Alterar(alunoAlterarRequest);
        return Ok(response);
    }

    /// <summary>
    /// Deleta um Aluno
    /// </summary>
    /// <param name="matricula"></param>
    /// <returns></returns>
    [HttpDelete("{matricula}")]
    public ActionResult Deletar(int matricula)
    {
        alunoAppServico.Deletar(matricula);
        return Ok();
    }

    /// <summary>
    /// Recupera uma listagem de alunos
    /// </summary>
    /// <param name="alunoListarRequest"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<AlunoResponse>> Listar([FromQuery] AlunoListarRequest alunoListarRequest)
    {
        IList<AlunoResponse> response = alunoAppServico.Listar(alunoListarRequest);
        return Ok(response);
    }
}
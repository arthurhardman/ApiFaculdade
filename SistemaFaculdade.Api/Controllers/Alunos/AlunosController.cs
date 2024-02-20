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

    [HttpPost]
    public ActionResult<AlunoResponse> Inserir(AlunoInserirRequest alunoInserirRequest)
    {
        AlunoResponse response = alunoAppServico.Inserir(alunoInserirRequest);
        return Ok(response);
    }

    [HttpGet("{matricula}")]
    public ActionResult<AlunoResponse> Recuperar(int matricula)
    {
        AlunoResponse response = alunoAppServico.Recuperar(matricula);
        return Ok(response);
    }

    [HttpPut]
    public ActionResult<AlunoResponse> Alterar(AlunoAlterarRequest alunoAlterarRequest)
    {
        AlunoResponse response = alunoAppServico.Alterar(alunoAlterarRequest);
        return Ok(response);
    }

    [HttpDelete("{matricula}")]
    public ActionResult Deletar(int matricula)
    {
        alunoAppServico.Deletar(matricula);
        return Ok();
    }

    [HttpGet]
    public ActionResult<IList<AlunoResponse>> Listar([FromQuery] AlunoListarRequest alunoListarRequest)
    {
        IList<AlunoResponse> response = alunoAppServico.Listar(alunoListarRequest);
        return Ok(response);
    }
}
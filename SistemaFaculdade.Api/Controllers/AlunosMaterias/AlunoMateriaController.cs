using Microsoft.AspNetCore.Mvc;
using SistemaFaculdade.Aplicacao.AlunosMaterias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Request;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Response;

namespace SistemaFaculdade.Api.Controllers.AlunosMaterias
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoMateriaController : ControllerBase
    {
        private readonly IAlunoMateriaAppServico alunoMateriaAppServico;

        public AlunoMateriaController(IAlunoMateriaAppServico alunoMateriaAppServico)
        {
            this.alunoMateriaAppServico = alunoMateriaAppServico;
        }

        [HttpPost]
        public ActionResult<AlunoMateriaResponse> Inserir(AlunoMateriaInserirRequest alunoMateriaInserir)
        {
            AlunoMateriaResponse response = alunoMateriaAppServico.Inserir(alunoMateriaInserir);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<AlunoMateriaResponse> Recuperar(int id)
        {
            AlunoMateriaResponse response = alunoMateriaAppServico.Recuperar(id);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult<AlunoMateriaResponse> Alterar(AlunoMateriaAtualizarRequest alunoMateriaAtualizar)
        {
            AlunoMateriaResponse response = alunoMateriaAppServico.Atualizar(alunoMateriaAtualizar);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            alunoMateriaAppServico.Excluir(id);
            return Ok();
        }
    }
}
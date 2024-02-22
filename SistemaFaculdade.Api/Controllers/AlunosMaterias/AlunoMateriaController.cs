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

        /// <summary>
        /// Insere um Aluno com Materia
        /// </summary>
        /// <param name="alunoMateriaInserir"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AlunoMateriaResponse> Inserir(AlunoMateriaInserirRequest alunoMateriaInserir)
        {
            AlunoMateriaResponse response = alunoMateriaAppServico.Inserir(alunoMateriaInserir);
            return Ok(response);
        }

        /// <summary>
        /// Recupera um Aluno com Materia por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<AlunoMateriaResponse> Recuperar(int id)
        {
            AlunoMateriaResponse response = alunoMateriaAppServico.Recuperar(id);
            return Ok(response);
        }

        /// <summary>
        /// Altera um Aluno com Materia
        /// </summary>
        /// <param name="alunoMateriaAtualizar"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<AlunoMateriaResponse> Alterar(AlunoMateriaAtualizarRequest alunoMateriaAtualizar)
        {
            AlunoMateriaResponse response = alunoMateriaAppServico.Atualizar(alunoMateriaAtualizar);
            return Ok(response);
        }

        /// <summary>
        /// Deleta um Aluno com Materia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            alunoMateriaAppServico.Excluir(id);
            return Ok();
        }
    }
}
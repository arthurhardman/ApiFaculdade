using SistemaFaculdade.DataTransfer.AtividadesExtras.Responses;
using SistemaFaculdade.DataTransfer.Enderecos.Responses;
using SistemaFaculdade.DataTransfer.Ocorrencias.Responses;
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.DataTransfer.Alunos.Responses
{
    public class AlunoResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnderecoResponse Endereco { get; set; }
        public string Numero { get; set; }
        public string Adicional { get; set; }
        public string DataMatricula { get; set; }
        public IList<AtividadeExtraListarResponse> AtividadeExtras { get; set; }
        public IList<OcorrenciaListarResponse> Ocorrencias { get; set; }
        public IList<Materia> Materias { get; set; }
    }
}
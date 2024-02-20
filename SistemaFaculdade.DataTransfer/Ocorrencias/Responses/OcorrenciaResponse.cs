using SistemaFaculdade.DataTransfer.Alunos.Responses;

namespace SistemaFaculdade.DataTransfer.Ocorrencias.Responses;

public class OcorrenciaResponse
{
    public string Descricao { get; set; }
    public AlunoResponse Aluno { get; set; }
}
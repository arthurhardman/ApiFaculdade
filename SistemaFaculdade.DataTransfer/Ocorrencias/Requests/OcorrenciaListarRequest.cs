using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.DataTransfer.Ocorrencias.Requests;

public class OcorrenciaListarRequest
{
    public string Descricao { get; set; }
    public Aluno Aluno { get; set; }
}
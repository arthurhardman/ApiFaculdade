namespace SistemaFaculdade.DataTransfer.Ocorrencias.Requests;

public class OcorrenciaAlterarRequest
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int MatriculaAluno { get; set; }
}
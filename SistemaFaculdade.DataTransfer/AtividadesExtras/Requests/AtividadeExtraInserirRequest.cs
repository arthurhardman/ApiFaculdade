using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.DataTransfer.AtividadesExtras.Requests;

public class AtividadeExtraInserirRequest
{
    public string Nome { get; set; }
    public int MatriculaAluno { get; set; }
}
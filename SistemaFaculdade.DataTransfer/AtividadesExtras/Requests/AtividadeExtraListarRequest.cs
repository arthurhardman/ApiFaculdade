using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.DataTransfer.AtividadesExtras.Requests;

public class AtividadeExtraListarRequest
{
    public string Nome { get; set; }
    public Aluno Aluno { get; set; }
}
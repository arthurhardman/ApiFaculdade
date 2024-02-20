using SistemaFaculdade.DataTransfer.Alunos.Responses;
using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.DataTransfer.AtividadesExtras.Responses;

public class AtividadeExtraResponse
{
    public string Nome { get; set; }
    public AlunoResponse Aluno { get; set; }
}
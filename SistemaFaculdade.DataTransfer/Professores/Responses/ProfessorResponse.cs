using SistemaFaculdade.DataTransfer.Enderecos.Responses;
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.DataTransfer.Professores.Responses;

public class ProfessorResponse
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public EnderecoResponse Endereco { get; set; }
    public string Cep { get; set; }
    public string Numero { get; set; }
    public string Adicional { get; set; }
    public DateTime DataRegistro { get; set; }
    public IList<Materia> Materias { get; set; }
}
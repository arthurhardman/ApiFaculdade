using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.DataTransfer.Professores.Requests;

public class ProfessorListarRequest
{
   public string Nome { get; set; }
   public string Email { get; set; }
   public string Senha { get; set; }
   public string Cep { get; set; }
   public string Numero { get; set; }
   public string Adicional { get; set; }
}
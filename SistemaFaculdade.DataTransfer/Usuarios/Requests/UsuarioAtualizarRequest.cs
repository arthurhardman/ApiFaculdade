namespace SistemaFaculdade.DataTransfer.Usuarios.Requests;

public class UsuarioAtualizarRequest
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public int TipoUsuario { get; set; }
    public int AtivoInativo { get; set; }
}
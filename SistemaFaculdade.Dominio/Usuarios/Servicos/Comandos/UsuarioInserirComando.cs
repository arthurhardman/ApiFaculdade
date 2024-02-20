namespace SistemaFaculdade.Dominio.Usuarios.Servicos.Comandos;

public class UsuarioInserirComando
{
    public string Nome { get; set; }
    public string Senha { get; set; }
    public int TipoUsuario { get; set; }
    public int AtivoInativo { get; set; }
}
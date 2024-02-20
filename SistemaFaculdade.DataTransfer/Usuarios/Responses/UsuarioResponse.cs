using SistemaFaculdade.Dominio.Usuarios.Enumeradores;

namespace SistemaFaculdade.DataTransfer.Usuarios.Responses;

public class UsuarioResponse
{
    public string Nome { get; set; }
    public EnumTipoUsuario TipoUsuario { get; set; }
    public EnumAtivoInativo AtivoInativo { get; set; }
}
using NHibernate;
using SistemaFaculdade.Dominio.Usuarios.Entidades;
using SistemaFaculdade.Dominio.Usuarios.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Usuarios.Repositorios;

public class UsuariosRepositorio : GenericoRepositorio<Usuario>, IUsuariosRepositorio
{
    public UsuariosRepositorio(ISession session) : base(session)
    {
    }
}
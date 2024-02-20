using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Usuarios.Entidades;
using SistemaFaculdade.Dominio.Usuarios.Enumeradores;

namespace SistemaFaculdade.Infra.Usuarios.Mapeamentos;

public class UsuarioMap : ClassMap<Usuario>
{
    public UsuarioMap()
    {
        Schema("sysfaculdade");
        Table("usuarios");
        Id(x => x.Id);
        Map(x => x.Nome, "nome");
        Map(x => x.Senha, "senha");
        Map(x => x.TipoUsuario, "tipousuario").CustomType<EnumTipoUsuario>();
        Map(x => x.AtivoInativo, "ativoinativo").CustomType<EnumAtivoInativo>();
        Map(x => x.Token, "token");
    }
}
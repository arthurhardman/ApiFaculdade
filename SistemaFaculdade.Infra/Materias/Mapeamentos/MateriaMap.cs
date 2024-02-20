using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Professores.Entidades;

namespace SistemaFaculdade.Infra.AtividadesExtras.Mapeamentos;

public class MateriaMap : ClassMap<Materia>
{
    public MateriaMap()
    {
        Schema("sysfaculdade");
        Table("materias");
        Id(ae => ae.Id).Column("Id");
        Map(ae => ae.Nome).Column("Nome");
    }
}
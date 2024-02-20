using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;

namespace SistemaFaculdade.Infra.PeriodosMaterias.Mapeamentos;

public class PeriodoMateriaMap : ClassMap<PeriodoMateria>
{
    public PeriodoMateriaMap()
    {
        Schema("sysfaculdade");
        Table("periodomateria");
        Id(x => x.Id);
        References(x => x.Materia).Column("idmateria");
        References(x => x.Periodo).Column("idperiodo");
    }
}
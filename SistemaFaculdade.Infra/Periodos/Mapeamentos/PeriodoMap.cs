using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Periodos.Entidades;

namespace SistemaFaculdade.Infra.Periodos.Mapeamentos;

public class PeriodoMap : ClassMap<Periodo>
{
    public PeriodoMap()
    {
        Schema("sysfaculdade");
        Table("periodo");
        Id(x => x.Id);
        Map(x => x.Nome, "Nome");
        Map(x => x.Turno, "Turno");

        HasManyToMany(aluno => aluno.Materias)
        .Table("periodomateria")
        .ParentKeyColumn("idperiodo")
        .ChildKeyColumn("idmateria")
        .Cascade.All();
    }
}
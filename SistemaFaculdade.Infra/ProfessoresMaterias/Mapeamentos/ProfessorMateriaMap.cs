using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;

namespace SistemaFaculdade.Infra.ProfessoresMaterias.Mapeamentos;

public class ProfessorMateriaMap : ClassMap<ProfessorMateria>
{
    public ProfessorMateriaMap()
    {
        Schema("sysfaculdade");
        Table("professormateria");
        Id(am => am.Id).Column("Id");
        References(am => am.Professor).Column("idprofessor");
        References(am => am.Materia).Column("idMateria");
    }
}
using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;

namespace SistemaFaculdade.Infra.AlunosMaterias.Mapeamentos;

public class AlunoMateriaMap : ClassMap<AlunoMateria>
{
    public AlunoMateriaMap()
    {
        Schema("sysfaculdade");
        Table("alunomateria");
        Id(am => am.Id).Column("Id");
        References(am => am.Aluno).Column("matriculaAluno");
        References(am => am.Materia).Column("idMateria");
    }
}
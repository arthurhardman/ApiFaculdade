using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Professores.Entidades;

namespace SistemaFaculdade.Infra.Professores.Mapeamentos;

public class ProfessorMap : ClassMap<Professor>
{
    public ProfessorMap()
    {
        Schema("sysfaculdade");
        Table("professores");
        Id(prof => prof.Id).Column("Id");
        Map(prof => prof.Nome).Column("Nome");
        Map(prof => prof.Email).Column("Email");
        Map(prof => prof.Senha).Column("Senha");
        Map(prof => prof.Cep).Column("Cep");
        Map(prof => prof.Numero).Column("Numero");
        Map(prof => prof.Adicional).Column("Adicional");
        Map(prof => prof.DataRegistro).Column("DataRegistro");
        References(prof => prof.Endereco).Column("IdEndereco");

        HasManyToMany(aluno => aluno.Materias)
        .Table("professormateria")
        .ParentKeyColumn("idprofessor")
        .ChildKeyColumn("idmateria")
        .Cascade.All();
    }
}
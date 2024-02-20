using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.Infra.Alunos.Mapeamentos;

public class AlunosMap : ClassMap<Aluno>
{
    public AlunosMap()
    {
        Schema("sysfaculdade");
        Table("alunos");
        Id(aluno => aluno.Matricula).Column("Matricula");
        Map(aluno => aluno.Nome).Column("Nome");
        Map(aluno => aluno.Email).Column("Email");
        Map(aluno => aluno.Senha).Column("Senha");
        Map(aluno => aluno.DataMatricula).Column("DataMatricula");
        Map(aluno => aluno.Cep).Column("Cep");
        Map(aluno => aluno.Numero).Column("Numero");
        Map(aluno => aluno.Adicional).Column("Adicional");
        References(aluno => aluno.Endereco).Column("IdEndereco");

        HasMany(aluno => aluno.AtividadeExtras)
            .KeyColumn("MatriculaAluno")
            .Cascade.All()
            .Inverse();

        HasMany(aluno => aluno.Ocorrencias)
            .KeyColumn("MatriculaAluno")
            .Cascade.All()
            .Inverse();

        HasManyToMany(aluno => aluno.Materias)
            .Table("alunomateria")
            .ParentKeyColumn("matriculaaluno")
            .ChildKeyColumn("idmateria")
            .Cascade.All();
    }
}
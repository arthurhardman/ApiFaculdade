using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;

namespace SistemaFaculdade.Infra.Ocorrencias.Mapeamentos;

public class OcorrenciaMap : ClassMap<Ocorrencia>
{
    public OcorrenciaMap()
    {
        Schema("sysfaculdade");
        Table("ocorrencias");
        Id(ae => ae.Id).Column("Id");
        Map(ae => ae.Descricao).Column("Descricao");
        References(a => a.Aluno).Column("MatriculaAluno");
    }
}
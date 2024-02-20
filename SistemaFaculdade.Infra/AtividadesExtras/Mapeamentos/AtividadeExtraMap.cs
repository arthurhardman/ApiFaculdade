using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;

namespace SistemaFaculdade.Infra.AtividadesExtras.Mapeamentos;

public class AtividadeExtraMap : ClassMap<AtividadeExtra>
{
    public AtividadeExtraMap()
    {
        Schema("sysfaculdade");
        Table("atividadesextras");
        Id(ae => ae.Id).Column("Id");
        Map(ae => ae.Nome).Column("Nome");
        References(ae => ae.Aluno, "MatriculaAluno");
    }
}
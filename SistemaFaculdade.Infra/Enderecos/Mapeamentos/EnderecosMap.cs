using FluentNHibernate.Mapping;
using SistemaFaculdade.Dominio.Enderecos.Entidades;

namespace SistemaFaculdade.Infra.Enderecos.Mapeamentos;

public class EnderecosMap : ClassMap<Endereco>
{
    public EnderecosMap()
    {
        Schema("sysfaculdade");
        Table("endereco");
        Id(endereco => endereco.Id).Column("id");
        Map(endereco => endereco.Cep).Column("cep");
        Map(endereco => endereco.Bairro).Column("bairro");
        Map(endereco => endereco.Logradouro).Column("logradouro");
        Map(endereco => endereco.Localidade).Column("localidade");
        Map(endereco => endereco.Uf).Column("uf");
    }
}
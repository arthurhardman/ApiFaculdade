using System.Text.Json.Serialization;

namespace SistemaFaculdade.Dominio.Enderecos.Servicos.Comandos;

public class EnderecoComando
{
    [JsonPropertyName("cep")]
    public virtual string Cep { get; set; }

    [JsonPropertyName("logradouro")]
    public virtual string Logradouro { get; set; }

    [JsonPropertyName("bairro")]
    public virtual string Bairro { get; set; }

    [JsonPropertyName("localidade")]
    public virtual string Localidade { get; set; }

    [JsonPropertyName("uf")]
    public virtual string Uf { get; set; }
}
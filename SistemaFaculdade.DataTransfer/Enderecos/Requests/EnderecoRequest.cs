namespace SistemaFaculdade.DataTransfer.Enderecos.Requests;

public class EnderecoRequest
{
    public virtual string Cep { get; set; }
    public virtual string Logradouro { get; set; }
    public virtual string Bairro { get; set; }
    public virtual string Localidade { get; set; }
    public virtual string Uf { get; set; }
}
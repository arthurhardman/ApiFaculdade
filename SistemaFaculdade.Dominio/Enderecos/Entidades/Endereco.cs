using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.Dominio.Enderecos.Entidades;

public class Endereco
{
   public virtual int Id { get; set; }
   public virtual string Cep { get; protected set; }
   public virtual string Logradouro { get; protected set; }
   public virtual string Bairro { get; protected set; }
   public virtual string Localidade { get; protected set; }
   public virtual string Uf { get; protected set; }

   protected Endereco() { }

   public Endereco(string cep, string logradouro, string bairro, string localidade, string uf)
   {
      SetCep(cep);
      SetLogradouro(logradouro);
      SetBairro(bairro);
      SetLocalidade(localidade);
      SetUf(uf);
   }

   public virtual void SetCep(string cep)
   {
      var troca = cep.Replace("-", "");

      if (troca.Length > 8)
      {
         throw new Exception("O CEP só pode ter 8 numeros");
      }

      Cep = troca;
   }

   public virtual void SetLogradouro(string logradouro)
   {
      if (logradouro.Length > 50)
      {
         throw new Exception("O logradouro só pode ter 50 caracteres");
      }

      Logradouro = logradouro;
   }

   public virtual void SetBairro(string bairro)
   {
      if (bairro.Length > 50)
      {
         throw new Exception("O bairro só pode ter 50 caracteres");
      }

      Bairro = bairro;
   }

   public virtual void SetLocalidade(string localidade)
   {
      if (localidade.Length > 50)
      {
         throw new Exception("O localidade só pode ter 50 caracteres");
      }

      Localidade = localidade;
   }

   public virtual void SetUf(string uf)
   {
      if (uf.Length > 2)
      {
         throw new Exception("O UF só pode ter 2 caracteres");
      }

      Uf = uf;
   }
}
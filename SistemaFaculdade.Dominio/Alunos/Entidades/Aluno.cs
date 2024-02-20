using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.Enderecos.Entidades;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;

namespace SistemaFaculdade.Dominio.Alunos.Entidades;

public class Aluno
{
    public virtual int Matricula { get; set; }
    public virtual string Nome { get; protected set; }
    public virtual string Email { get; protected set; }
    public virtual string Senha { get; protected set; }
    public virtual string Cep { get; protected set; }
    public virtual Endereco Endereco { get; protected set; }
    public virtual string Numero { get; protected set; }
    public virtual string Adicional { get; protected set; }
    public virtual DateTime DataMatricula { get; protected set; }

    public virtual IList<AtividadeExtra> AtividadeExtras { get; set; } = new List<AtividadeExtra>();
    public virtual IList<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
    public virtual IList<Materia> Materias { get; set; } = new List<Materia>();

    protected Aluno() { }

    public Aluno(string nome, string email, string senha, string cep, string numero, string adicional, Endereco endereco)
    {
        SetNome(nome);
        SetEmail(email);
        SetSenha(senha);
        SetNumero(numero);
        SetCep(cep);
        SetAdicional(adicional);
        SetEndereco(endereco);
        DataMatricula = DateTime.Now;
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O Nome não pode ser nulo");
        }
        else if (nome.Length > 50)
        {
            throw new Exception("O nome deve ter menos de 50 caracteres");
        }

        Nome = nome;
    }

    public virtual void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("O Email não pode ser nulo");
        }
        else if (email.Length > 100)
        {
            throw new Exception("O email deve ter menos de 100 caracteres");
        }

        Email = email;
    }

    public virtual void SetSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
        {
            throw new Exception("A senha não pode ser nulo");
        }
        else if (senha.Length > 12)
        {
            throw new Exception("A senha deve ter menos de 12 caracteres");
        }

        Senha = senha;
    }

    public virtual void SetCep(string cep)
    {
        var troca = cep.Replace("-", "");

        if (string.IsNullOrWhiteSpace(troca))
        {
            throw new Exception("O cep não pode ser nulo");
        }
        else if (troca.Length > 8)
        {
            throw new Exception("O CEP deve ter menos de 8 caracteres");
        }

        Cep = troca;
    }

    public virtual void SetNumero(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
        {
            throw new Exception("O numero não pode ser nulo");
        }
        else if (numero.Length > 8)
        {
            throw new Exception("O Numero deve ter menos de 8 caracteres");
        }

        Numero = numero;
    }

    public virtual void SetAdicional(string adicional)
    {
        if (string.IsNullOrWhiteSpace(adicional))
        {
            throw new Exception("O adicional não pode ser nulo");
        }
        else if (adicional.Length > 100)
        {
            throw new Exception("O adicional deve ter menos de 100 caracteres");
        }

        Adicional = adicional;
    }

    public virtual void SetEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }
}
using System.Reflection;
using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.Dominio.AtividadesExtras.Entidades;

public class AtividadeExtra
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; protected set; }
    public virtual Aluno Aluno { get; protected set; }

    protected AtividadeExtra() { }

    public AtividadeExtra(string nome, Aluno aluno)
    {
        SetNome(nome);
        SetAluno(aluno);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O Nome não pode ser nulo");
        }
        else if (nome.Length > 100)
        {
            throw new Exception("O nome deve ter menos de 100 caracteres");
        }

        Nome = nome;
    }

    public virtual void SetAluno(Aluno aluno)
    {
        Aluno = aluno ?? throw new Exception("O Nome do aluno não pode ser nulo");
    }
}
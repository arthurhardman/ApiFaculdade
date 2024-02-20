using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.Dominio.Ocorrencias.Entidades;

public class Ocorrencia
{
    public virtual int Id { get; set; }
    public virtual string Descricao { get; protected set; }
    public virtual Aluno Aluno { get; protected set; }
    protected Ocorrencia() { }
    public Ocorrencia(string descricao, Aluno aluno)
    {
        SetDescricao(descricao);
        SetAluno(aluno);
    }

    public virtual void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
        {
            throw new Exception("A descricao não pode ser nulo");
        }
        else if (descricao.Length > 100)
        {
            throw new Exception("A descricao deve ter menos de 100 caracteres");
        }

        Descricao = descricao;
    }

    public virtual void SetAluno(Aluno aluno)
    {
        Aluno = aluno ?? throw new Exception("O Nome do aluno não pode ser nulo");
    }
}
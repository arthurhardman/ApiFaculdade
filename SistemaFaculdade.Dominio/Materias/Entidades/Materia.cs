namespace SistemaFaculdade.Dominio.Materias.Entidades;

public class Materia
{
    public virtual int Id { get; protected set; }
    public virtual string Nome { get; protected set; }
    protected Materia() { }

    public Materia(string nome)
    {
        SetNome(nome);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            throw new Exception("O Nome não pode ser nulo");
        }

        Nome = nome;
    }
}
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.Dominio.Periodos.Entidades;

public class Periodo
{
    public virtual int Id { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual string Turno { get; protected set; }
    public virtual IList<Materia> Materias { get; set; } = new List<Materia>();
    protected Periodo() { }

    public Periodo(string nome, string turno)
    {
        SetNome(nome);
        SetTurno(turno);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("O nome não pode ser nulo");

        if (nome.Length > 45)
            throw new Exception("O nome não pode ter mais de 45 caracteres");

        Nome = nome;
    }

    public virtual void SetTurno(string turno)
    {
        if (string.IsNullOrWhiteSpace(turno))
            throw new Exception("O turno não pode ser nulo");

        if (turno.Length > 45)
            throw new Exception("O turno não pode ter mais de 45 caracteres");

        Turno = turno;
    }
}
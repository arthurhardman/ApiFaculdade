using SistemaFaculdade.Dominio.Usuarios.Enumeradores;

namespace SistemaFaculdade.Dominio.Usuarios.Entidades;

public class Usuario
{
    public virtual int Id { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual string Senha { get; protected set; }
    public virtual Guid Token { get; protected set; }
    public virtual EnumTipoUsuario TipoUsuario { get; protected set; }
    public virtual EnumAtivoInativo AtivoInativo { get; protected set; }

    protected Usuario() { }

    public Usuario(string nome, string senha, int tipoUsuario, int ativoInativo)
    {
        SetNome(nome);
        SetSenha(senha);
        SetTipoUsuario(tipoUsuario);
        SetToken();
        SetAtivoInativo(ativoInativo);
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

    public virtual void SetSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
        {
            throw new Exception("A Senha não pode ser nulo");
        }
        else if (senha.Length > 20)
        {
            throw new Exception("A Senha deve ter menos de 20 caracteres");
        }

        Senha = senha;
    }

    public virtual void SetTipoUsuario(int tipoUsuario)
    {
        TipoUsuario = tipoUsuario switch
        {
            1 => EnumTipoUsuario.Aluno,
            2 => EnumTipoUsuario.Professor,
            3 => EnumTipoUsuario.Diretor,
            _ => throw new Exception("Não existe esse tipo de usuario"),
        };
    }

    public virtual void SetToken()
    {
        Guid guid = Guid.NewGuid();

        Token = guid;
    }

    public virtual void SetAtivoInativo(int ativoInativo)
    {
        AtivoInativo = ativoInativo switch
        {
            1 => EnumAtivoInativo.Ativo,
            0 => EnumAtivoInativo.Inativo,
            _ => throw new Exception("Não existe essa opção"),
        };
    }
}
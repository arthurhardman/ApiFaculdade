using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Materias.Repositorios;
using SistemaFaculdade.Dominio.Materias.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.Materias.Servicos;

public class MateriaServico : IMateriaServico
{
    private readonly IMateriaRepositorio materiaRepositorio;

    public MateriaServico(IMateriaRepositorio materiaRepositorio)
    {
        this.materiaRepositorio = materiaRepositorio;
    }

    public Materia Atualizar(Materia comando)
    {
        Materia materia = Validar(comando.Id);
        materia.SetNome(comando.Nome);

        return materiaRepositorio.Alterar(materia);
    }

    public void Excluir(int id)
    {
        Materia materia = Validar(id);
        materiaRepositorio.Remover(materia);
    }

    public Materia Inserir(Materia comando)
    {
        Materia materia = Instanciar(comando);

        return materiaRepositorio.Inserir(materia);
    }

    public Materia Instanciar(Materia comando)
    {
        return new Materia(comando.Nome);
    }

    public Materia Validar(int id)
    {
        Materia materia = materiaRepositorio.Recuperar(id) ?? throw new Exception("Materia inexistente");

        return materia;
    }
}
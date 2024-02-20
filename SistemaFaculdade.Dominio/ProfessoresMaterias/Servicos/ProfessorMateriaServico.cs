using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Materias.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Professores.Entidades;
using SistemaFaculdade.Dominio.Professores.Servicos.Interfaces;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Repositorios;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Comandos;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos;

public class ProfessorMateriaServico : IProfessorMateriaServico
{
    private readonly IProfessorMateriasRepositorio professorMateriasRepositorio;
    private readonly IProfessorServico professorServico;
    private readonly IMateriaServico materiaServico;

    public ProfessorMateriaServico(IProfessorMateriasRepositorio professorMateriasRepositorio, IProfessorServico professorServico, IMateriaServico materiaServico)
    {
        this.professorMateriasRepositorio = professorMateriasRepositorio;
        this.professorServico = professorServico;
        this.materiaServico = materiaServico;
    }

    public ProfessorMateria Atualizar(ProfessorMateriaAtualizarComando professorMateria)
    {
        Professor professor = professorServico.Validar(professorMateria.IdProfessor);
        Materia materia = materiaServico.Validar(professorMateria.IdMateria);
        ProfessorMateria professorMateria1 = Validar(professorMateria.Id);

        if (professor.Materias.Contains(materia))
            throw new Exception("Esse professor já possui essa materia");

        professorMateria1.SetMateria(materia);
        professorMateria1.SetProfessor(professor);

        return professorMateriasRepositorio.Alterar(professorMateria1);
    }

    public void Excluir(int id)
    {
        ProfessorMateria professorMateria = Validar(id);
        professorMateriasRepositorio.Remover(professorMateria);
    }

    public ProfessorMateria Inserir(ProfessorMateriaInserirComando professorMateria)
    {
        ProfessorMateria professorMat = Instanciar(professorMateria);
        professorMateriasRepositorio.Inserir(professorMat);

        return professorMat;
    }

    public ProfessorMateria Instanciar(ProfessorMateriaInserirComando professorMateria)
    {
        Professor professor = professorServico.Validar(professorMateria.IdProfessor);
        Materia materia = materiaServico.Validar(professorMateria.IdMateria);

        if (professor.Materias.Contains(materia))
            throw new Exception("Esse professor já possui essa materia");

        return new ProfessorMateria(professor, materia);
    }

    public ProfessorMateria Validar(int id)
    {
        ProfessorMateria professorMateria = professorMateriasRepositorio.Recuperar(id) ?? throw new Exception("A parametrização não existe");

        return professorMateria;
    }
}
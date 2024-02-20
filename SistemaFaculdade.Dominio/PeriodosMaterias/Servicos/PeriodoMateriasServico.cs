using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Materias.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Periodos.Entidades;
using SistemaFaculdade.Dominio.Periodos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;
using SistemaFaculdade.Dominio.PeriodosMaterias.Repositorios;
using SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Comandos;
using SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.PeriodosMaterias.Servicos;

public class PeriodoMateriasServico : IPeriodoMateriasServico
{
    private readonly IPeriodoMateriaRepositorio periodoMateriaRepositorio;
    private readonly IPeriodoServico periodoServico;
    private readonly IMateriaServico materiaServico;

    public PeriodoMateriasServico(IPeriodoMateriaRepositorio periodoMateriaRepositorio, IPeriodoServico periodoServico, IMateriaServico materiaServico)
    {
        this.periodoMateriaRepositorio = periodoMateriaRepositorio;
        this.periodoServico = periodoServico;
        this.materiaServico = materiaServico;
    }

    public PeriodoMateria Atualizar(PeriodosMateriasAtualizarComando periodoMateria)
    {
        PeriodoMateria periodoMateria1 = Validar(periodoMateria.Id);
        Materia materia = materiaServico.Validar(periodoMateria.IdMateria);
        Periodo periodo = periodoServico.Validar(periodoMateria.IdPeriodo);

        if (periodo.Materias.Contains(materia))
            throw new Exception("Esse periodo já possui essa matéria");

        periodoMateria1.SetMateria(materia);
        periodoMateria1.SetPeriodo(periodo);

        return periodoMateriaRepositorio.Alterar(periodoMateria1);
    }

    public void Excluir(int id)
    {
        PeriodoMateria periodoMateria = Validar(id);
        periodoMateriaRepositorio.Remover(periodoMateria);
    }

    public PeriodoMateria Inserir(PeriodosMateriasInserirComando periodoMateria)
    {
        PeriodoMateria periodoMat = Instanciar(periodoMateria);

        return periodoMateriaRepositorio.Inserir(periodoMat);
    }

    public PeriodoMateria Instanciar(PeriodosMateriasInserirComando periodoMateria)
    {
        Materia materia = materiaServico.Validar(periodoMateria.IdMateria);
        Periodo periodo = periodoServico.Validar(periodoMateria.IdPeriodo);

        if (periodo.Materias.Contains(materia))
            throw new Exception("Esse periodo já possui essa matéria");

        return new PeriodoMateria(periodo, materia);
    }

    public PeriodoMateria Validar(int id)
    {
        PeriodoMateria periodoMateria = periodoMateriaRepositorio.Recuperar(id) ?? throw new Exception("O periodo não pode ficar sem matérias");

        return periodoMateria;
    }
}
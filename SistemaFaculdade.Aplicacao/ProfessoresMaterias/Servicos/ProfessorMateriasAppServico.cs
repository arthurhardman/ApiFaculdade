using AutoMapper;
using SistemaFaculdade.Aplicacao.ProfessoresMaterias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Requests;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Responses;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Comandos;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.ProfessoresMaterias.Servicos;

public class ProfessorMateriasAppServico : IProfessorMateriasAppServico
{
    private readonly IProfessorMateriaServico professorMateriasServico;
    private readonly IMapper mapper;

    public ProfessorMateriasAppServico(IProfessorMateriaServico professorMateriasServico, IMapper mapper)
    {
        this.professorMateriasServico = professorMateriasServico;
        this.mapper = mapper;
    }

    public ProfessorMateriasResponse Atualizar(ProfessorMateriasAtualizarRequest professorMateria)
    {
        ProfessorMateriaAtualizarComando comando = mapper.Map<ProfessorMateriaAtualizarComando>(professorMateria);
        ProfessorMateria professorMateria1 = professorMateriasServico.Atualizar(comando);

        ProfessorMateriasResponse response = mapper.Map<ProfessorMateriasResponse>(professorMateria1);
        return response;
    }

    public void Excluir(int id)
    {
        professorMateriasServico.Excluir(id);
    }

    public ProfessorMateriasResponse Inserir(ProfessorMateriasInserirRequest professorMateria)
    {
        ProfessorMateriaInserirComando comando = mapper.Map<ProfessorMateriaInserirComando>(professorMateria);
        ProfessorMateria professorMateria1 = professorMateriasServico.Inserir(comando);

        ProfessorMateriasResponse response = mapper.Map<ProfessorMateriasResponse>(professorMateria1);
        return response;
    }

    public ProfessorMateriasResponse Recuperar(int id)
    {
        ProfessorMateria professorMateria = professorMateriasServico.Validar(id);

        ProfessorMateriasResponse response = mapper.Map<ProfessorMateriasResponse>(professorMateria);
        return response;
    }
}
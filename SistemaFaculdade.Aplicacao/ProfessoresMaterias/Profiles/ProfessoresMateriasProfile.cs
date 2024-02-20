using AutoMapper;
using SistemaFaculdade.DataTransfer.Professores.Requests;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Requests;
using SistemaFaculdade.DataTransfer.ProfessoresMaterias.Responses;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Entidades;
using SistemaFaculdade.Dominio.ProfessoresMaterias.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.ProfessoresMaterias.Profiles;

public class ProfessoresMateriasProfile : Profile
{
    public ProfessoresMateriasProfile()
    {
        CreateMap<ProfessorMateriasAtualizarRequest, ProfessorMateriaAtualizarComando>();
        CreateMap<ProfessorMateriasInserirRequest, ProfessorMateriaInserirComando>();
        CreateMap<ProfessorMateria, ProfessorMateriasResponse>();
    }
}
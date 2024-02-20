using AutoMapper;
using SistemaFaculdade.DataTransfer.Materias.Requests;
using SistemaFaculdade.DataTransfer.Materias.Responses;
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.Aplicacao.Materias.Profiles;

public class MateriaProfile : Profile
{
    public MateriaProfile()
    {
        CreateMap<MateriaInserirRequest, Materia>();
        CreateMap<MateriaAlterarRequest, Materia>();
        CreateMap<Materia, MateriaResponse>();
    }
}
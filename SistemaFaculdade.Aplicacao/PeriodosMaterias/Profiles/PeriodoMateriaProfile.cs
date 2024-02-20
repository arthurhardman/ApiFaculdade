using AutoMapper;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Requests;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Responses;
using SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;
using SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.PeriodosMaterias.Profiles;

public class PeriodoMateriaProfile : Profile
{
    public PeriodoMateriaProfile()
    {
        CreateMap<PeriodosMateriasInserirRequest, PeriodosMateriasInserirComando>();
        CreateMap<PeriodosMateriasAtualizarRequest, PeriodosMateriasAtualizarComando>();
        CreateMap<PeriodoMateria, PeriodosMateriasResponse>();
    }
}
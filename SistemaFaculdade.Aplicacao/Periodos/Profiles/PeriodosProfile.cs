using AutoMapper;
using SistemaFaculdade.DataTransfer.Periodos.Requests;
using SistemaFaculdade.DataTransfer.Periodos.Responses;
using SistemaFaculdade.Dominio.Periodos.Entidades;
using SistemaFaculdade.Dominio.Periodos.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.Pedidos.Profiles;

public class PeriodosProfile : Profile
{
    public PeriodosProfile()
    {
        CreateMap<PeriodosInserirRequest, PeriodoInserirComando>();
        CreateMap<PeriodosAtualizarRequest, PeriodoAtualizarComando>();
        CreateMap<Periodo, PeriodosResponse>();
    }
}
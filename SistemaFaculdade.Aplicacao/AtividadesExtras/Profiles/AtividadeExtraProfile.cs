using AutoMapper;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Requests;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Responses;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.AtividadesExtras.Profiles;

public class AtividadeExtraProfile : Profile
{
    public AtividadeExtraProfile()
    {
        CreateMap<AtividadeExtraInserirRequest, AtividadeExtra>();
        CreateMap<AtividadeExtraAlterarRequest, AtividadeExtra>();
        CreateMap<AtividadeExtra, AtividadeExtraResponse>();
        CreateMap<AtividadeExtra, AtividadeExtraListarResponse>();
        CreateMap<AtividadeExtraInserirRequest, AtividadeExtraInserirComando>();
        CreateMap<AtividadeExtraAlterarRequest, AtividadeExtraAlterarComando>();
    }
}
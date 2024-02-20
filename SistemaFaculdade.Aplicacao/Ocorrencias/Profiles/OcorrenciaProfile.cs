using AutoMapper;
using SistemaFaculdade.DataTransfer.Ocorrencias.Requests;
using SistemaFaculdade.DataTransfer.Ocorrencias.Responses;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.Ocorrencias.Profiles;

public class OcorrenciaProfile : Profile
{
    public OcorrenciaProfile()
    {
        CreateMap<OcorrenciaInserirRequest, Ocorrencia>();
        CreateMap<OcorrenciaAlterarRequest, Ocorrencia>();
        CreateMap<Ocorrencia, OcorrenciaResponse>();
        CreateMap<Ocorrencia, OcorrenciaListarResponse>();
        CreateMap<OcorrenciaInserirRequest, OcorrenciaInserirComando>();
        CreateMap<OcorrenciaAlterarRequest, OcorrenciaAlterarComando>();
    }
}
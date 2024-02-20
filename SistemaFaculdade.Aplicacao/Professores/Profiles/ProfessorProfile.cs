using AutoMapper;
using SistemaFaculdade.DataTransfer.Professores.Requests;
using SistemaFaculdade.DataTransfer.Professores.Responses;
using SistemaFaculdade.Dominio.Professores.Entidades;
using SistemaFaculdade.Dominio.Professores.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.Professores.Profiles;

public class ProfessorProfile : Profile
{
    public ProfessorProfile()
    {
        CreateMap<ProfessorInserirRequest, Professor>();
        CreateMap<ProfessorAlterarRequest, Professor>();
        CreateMap<ProfessorListarRequest, Professor>();
        CreateMap<Professor, ProfessorResponse>();
        CreateMap<ProfessorInserirRequest, ProfessorInserirComando>();
        CreateMap<ProfessorAlterarRequest, ProfessorAlterarComando>();
    }
}
using AutoMapper;
using SistemaFaculdade.DataTransfer.Alunos.Requests;
using SistemaFaculdade.DataTransfer.Alunos.Responses;
using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.Aplicacao.Alunos.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<AlunoInserirRequest, Aluno>();
        CreateMap<AlunoAlterarRequest, Aluno>();
        CreateMap<Aluno, AlunoResponse>();
    }
}
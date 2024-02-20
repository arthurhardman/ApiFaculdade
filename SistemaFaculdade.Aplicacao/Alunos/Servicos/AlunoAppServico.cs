using AutoMapper;
using SistemaFaculdade.Aplicacao.Alunos.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Alunos.Requests;
using SistemaFaculdade.DataTransfer.Alunos.Responses;
using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Repositorios;
using SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.Alunos.Servicos;

public class AlunoAppServico : IAlunoAppServico
{
    private readonly IAlunoServico alunoServico;
    private readonly IMapper mapper;
    private readonly IAlunoRepositorio alunoRepositorio;
    private readonly IEnderecoServico enderecoServico;

    public AlunoAppServico(
        IAlunoServico alunoServico,
        IMapper mapper,
        IAlunoRepositorio alunoRepositorio,
        IEnderecoServico enderecoServico)
    {
        this.alunoServico = alunoServico;
        this.mapper = mapper;
        this.alunoRepositorio = alunoRepositorio;
        this.enderecoServico = enderecoServico;
    }

    public AlunoResponse Alterar(AlunoAlterarRequest alunoRequest)
    {
        var comando = mapper.Map<Aluno>(alunoRequest);

        Aluno aluno = alunoServico.Atualizar(comando);

        AlunoResponse alunoResponse = mapper.Map<AlunoResponse>(aluno);
        return alunoResponse;
    }

    public void Deletar(int matricula)
    {
        alunoServico.Excluir(matricula);
    }

    public AlunoResponse Inserir(AlunoInserirRequest alunoRequest)
    {
        Aluno aluno = mapper.Map<Aluno>(alunoRequest);
        aluno = alunoServico.Inserir(aluno);

        AlunoResponse response = mapper.Map<AlunoResponse>(aluno);
        return response;
    }

    public IList<AlunoResponse> Listar(AlunoListarRequest alunoRequest)
    {
        IList<Aluno> alunos = alunoRepositorio.Listar(alunoRequest.Nome);
        foreach (var aluno in alunos)
        {
            aluno.SetEndereco(enderecoServico.Validar(aluno.Cep));
        }

        IList<AlunoResponse> responses = mapper.Map<IList<AlunoResponse>>(alunos);
        return responses;
    }

    public AlunoResponse Recuperar(int matricula)
    {
        Aluno aluno = alunoServico.Validar(matricula);
        AlunoResponse response = mapper.Map<AlunoResponse>(aluno);
        return response;
    }
}
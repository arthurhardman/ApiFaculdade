using AutoMapper;
using SistemaFaculdade.Aplicacao.Professores.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Professores.Requests;
using SistemaFaculdade.DataTransfer.Professores.Responses;
using SistemaFaculdade.Dominio.Enderecos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Professores.Entidades;
using SistemaFaculdade.Dominio.Professores.Repositorios;
using SistemaFaculdade.Dominio.Professores.Servicos.Comandos;
using SistemaFaculdade.Dominio.Professores.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.Professores.Servicos;

public class ProfessorAppServico : IProfessorAppServico
{
    private readonly IProfessorServico professorServico;
    private readonly IMapper mapper;
    private readonly IProfessorRepositorio professorRepositorio;
    private readonly IEnderecoServico enderecoServico;

    public ProfessorAppServico(
        IProfessorServico professorServico,
        IMapper mapper,
        IProfessorRepositorio professorRepositorio,
        IEnderecoServico enderecoServico)
    {
        this.professorServico = professorServico;
        this.mapper = mapper;
        this.professorRepositorio = professorRepositorio;
        this.enderecoServico = enderecoServico;
    }

    public ProfessorResponse Alterar(ProfessorAlterarRequest professorAlterarRequest)
    {
        var comando = mapper.Map<ProfessorAlterarComando>(professorAlterarRequest);

        Professor professor = professorServico.Atualizar(comando);

        ProfessorResponse alunoResponse = mapper.Map<ProfessorResponse>(professor);
        return alunoResponse;
    }

    public void Deletar(int id)
    {
        professorServico.Excluir(id);
    }

    public ProfessorResponse Inserir(ProfessorInserirRequest professorInserirRequest)
    {
        var comando = mapper.Map<ProfessorInserirComando>(professorInserirRequest);
        Professor professor = professorServico.Inserir(comando);

        ProfessorResponse response = mapper.Map<ProfessorResponse>(professor);
        return response;
    }

    public IList<ProfessorResponse> Listar(ProfessorListarRequest professorRequest)
    {
        IList<Professor> professores = professorRepositorio.Listar(professorRequest.Nome);
        foreach (var professor in professores)
        {
            professor.SetEndereco(enderecoServico.Validar(professor.Cep));
        }

        IList<ProfessorResponse> responses = mapper.Map<IList<ProfessorResponse>>(professores);
        return responses;
    }

    public ProfessorResponse Recuperar(int id)
    {
        Professor professor = professorServico.Validar(id);
        ProfessorResponse response = mapper.Map<ProfessorResponse>(professor);
        return response;
    }
}
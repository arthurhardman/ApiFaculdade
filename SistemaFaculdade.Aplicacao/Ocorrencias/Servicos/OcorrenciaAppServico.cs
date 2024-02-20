using AutoMapper;
using SistemaFaculdade.Aplicacao.Ocorrencias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Ocorrencias.Requests;
using SistemaFaculdade.DataTransfer.Ocorrencias.Responses;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Repositorios;
using SistemaFaculdade.Dominio.Ocorrencias.Servicos.Comandos;
using SistemaFaculdade.Dominio.Ocorrencias.Servicos.Interface;

namespace SistemaFaculdade.Aplicacao.Ocorrencias.Servicos;

public class OcorrenciaAppServico : IOcorrenciaAppServico
{
    private readonly IOcorrenciaRepositorio ocorrenciaRepositorio;
    private readonly IMapper mapper;
    private readonly IOcorrenciaServico ocorrenciaServico;

    public OcorrenciaAppServico(IOcorrenciaRepositorio ocorrenciaRepositorio, IMapper mapper, IOcorrenciaServico ocorrenciaServico)
    {
        this.ocorrenciaRepositorio = ocorrenciaRepositorio;
        this.mapper = mapper;
        this.ocorrenciaServico = ocorrenciaServico;
    }

    public OcorrenciaResponse Alterar(OcorrenciaAlterarRequest ocorrenciaRequest)
    {
        var comando = mapper.Map<OcorrenciaAlterarComando>(ocorrenciaRequest);
        Ocorrencia ocorrencia = ocorrenciaServico.Atualizar(comando);

        OcorrenciaResponse response = mapper.Map<OcorrenciaResponse>(ocorrencia);
        return response;
    }

    public void Deletar(int id)
    {
        Ocorrencia ocorrencia = ocorrenciaServico.Validar(id);
        ocorrenciaRepositorio.Remover(ocorrencia);
    }

    public OcorrenciaResponse Inserir(OcorrenciaInserirRequest ocorrenciaRequest)
    {
        var comando = mapper.Map<OcorrenciaInserirComando>(ocorrenciaRequest);
        Ocorrencia ocorrencia = ocorrenciaServico.Inserir(comando);

        OcorrenciaResponse response = mapper.Map<OcorrenciaResponse>(ocorrencia);
        return response;
    }

    public OcorrenciaResponse Recuperar(int id)
    {
        Ocorrencia ocorrencia = ocorrenciaServico.Validar(id);
        OcorrenciaResponse response = mapper.Map<OcorrenciaResponse>(ocorrencia);
        return response;
    }
}
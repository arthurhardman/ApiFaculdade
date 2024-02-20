using AutoMapper;
using SistemaFaculdade.Aplicacao.AtividadesExtras.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Requests;
using SistemaFaculdade.DataTransfer.AtividadesExtras.Responses;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.AtividadesExtras.Repositorios;
using SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Comandos;
using SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.AtividadesExtras.Servicos;

public class AtividadeExtraAppServico : IAtividadeExtraAppServico
{
    private readonly IAtividadeExtraServico atividadeExtraServico;
    private readonly IMapper mapper;
    private readonly IAtividadeExtraRepositorio atividadeExtraRepositorio;

    public AtividadeExtraAppServico(IAtividadeExtraServico atividadeExtraServico, IMapper mapper, IAtividadeExtraRepositorio atividadeExtraRepositorio)
    {
        this.atividadeExtraServico = atividadeExtraServico;
        this.mapper = mapper;
        this.atividadeExtraRepositorio = atividadeExtraRepositorio;
    }


    public AtividadeExtraResponse Alterar(AtividadeExtraAlterarRequest atividadeExtraRequest)
    {
        var comando = mapper.Map<AtividadeExtraAlterarComando>(atividadeExtraRequest);
        AtividadeExtra atividadeExtra = atividadeExtraServico.Atualizar(comando);

        AtividadeExtraResponse response = mapper.Map<AtividadeExtraResponse>(atividadeExtra);
        return response;
    }

    public void Deletar(int id)
    {
        AtividadeExtra atividadeExtra = atividadeExtraServico.Validar(id);
        atividadeExtraRepositorio.Remover(atividadeExtra);
    }

    public AtividadeExtraResponse Inserir(AtividadeExtraInserirRequest atividadeExtraRequest)
    {
        var comando = mapper.Map<AtividadeExtraInserirComando>(atividadeExtraRequest);
        AtividadeExtra atividadeExtras = atividadeExtraServico.Inserir(comando);

        AtividadeExtraResponse response = mapper.Map<AtividadeExtraResponse>(atividadeExtras);
        return response;
    }

    public IList<AtividadeExtraResponse> Listar(AtividadeExtraListarRequest atividadeExtraRequest)
    {
        IList<AtividadeExtra> atividadeExtras = atividadeExtraRepositorio.Listar(atividadeExtraRequest.Nome);
        IList<AtividadeExtraResponse> response = mapper.Map<IList<AtividadeExtraResponse>>(atividadeExtras);
        return response;
    }

    public AtividadeExtraResponse Recuperar(int id)
    {
        AtividadeExtra atividadeExtra = atividadeExtraServico.Validar(id);
        AtividadeExtraResponse response = mapper.Map<AtividadeExtraResponse>(atividadeExtra);
        return response;
    }
}
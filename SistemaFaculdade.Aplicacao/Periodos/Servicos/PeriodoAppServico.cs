using AutoMapper;
using SistemaFaculdade.Aplicacao.Periodos.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Periodos.Requests;
using SistemaFaculdade.DataTransfer.Periodos.Responses;
using SistemaFaculdade.Dominio.Periodos.Entidades;
using SistemaFaculdade.Dominio.Periodos.Servicos.Comandos;
using SistemaFaculdade.Dominio.Periodos.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.Periodos.Servicos;

public class PeriodoAppServico : IPeriodoAppServico
{
    private readonly IPeriodoServico periodoServico;
    private readonly IMapper mapper;

    public PeriodoAppServico(IPeriodoServico periodoServico, IMapper mapper)
    {
        this.periodoServico = periodoServico;
        this.mapper = mapper;
    }

    public PeriodosResponse Atualizar(PeriodosAtualizarRequest periodo)
    {
        PeriodoAtualizarComando comando = mapper.Map<PeriodoAtualizarComando>(periodo);

        Periodo objeto = periodoServico.Atualizar(comando);

        PeriodosResponse response = mapper.Map<PeriodosResponse>(objeto);
        return response;
    }

    public void Excluir(int id)
    {
        periodoServico.Excluir(id);
    }

    public PeriodosResponse Inserir(PeriodosInserirRequest periodo)
    {
        PeriodoInserirComando comando = mapper.Map<PeriodoInserirComando>(periodo);

        Periodo objeto = periodoServico.Inserir(comando);

        PeriodosResponse response = mapper.Map<PeriodosResponse>(objeto);
        return response;
    }

    public PeriodosResponse Recuperar(int id)
    {
        Periodo periodo = periodoServico.Validar(id);

        PeriodosResponse response = mapper.Map<PeriodosResponse>(periodo);
        return response;
    }
}
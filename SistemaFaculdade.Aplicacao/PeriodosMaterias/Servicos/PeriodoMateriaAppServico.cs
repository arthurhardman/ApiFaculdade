using AutoMapper;
using Org.BouncyCastle.Asn1.Ocsp;
using SistemaFaculdade.Aplicacao.PeriodosMaterias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Requests;
using SistemaFaculdade.DataTransfer.PeriodosMaterias.Responses;
using SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;
using SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Comandos;
using SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.PeriodosMaterias.Servicos;

public class PeriodoMateriaAppServico : IPeriodoMateriaAppServico
{
    private readonly IMapper mapper;
    private readonly IPeriodoMateriasServico periodoMateriasServico;

    public PeriodoMateriaAppServico(IMapper mapper, IPeriodoMateriasServico periodoMateriasServico)
    {
        this.mapper = mapper;
        this.periodoMateriasServico = periodoMateriasServico;
    }

    public PeriodosMateriasResponse Atualizar(PeriodosMateriasAtualizarRequest periodosMateriasAtualizar)
    {
        PeriodosMateriasAtualizarComando comando = mapper.Map<PeriodosMateriasAtualizarComando>(periodosMateriasAtualizar);
        PeriodoMateria periodoMateria = periodoMateriasServico.Atualizar(comando);

        PeriodosMateriasResponse response = mapper.Map<PeriodosMateriasResponse>(periodoMateria);
        return response;
    }

    public void Excluir(int id)
    {
        periodoMateriasServico.Excluir(id);
    }

    public PeriodosMateriasResponse Inserir(PeriodosMateriasInserirRequest periodosMateriasInserir)
    {
        PeriodosMateriasInserirComando comando = mapper.Map<PeriodosMateriasInserirComando>(periodosMateriasInserir);
        PeriodoMateria periodoMateria = periodoMateriasServico.Inserir(comando);

        PeriodosMateriasResponse response = mapper.Map<PeriodosMateriasResponse>(periodoMateria);
        return response;
    }

    public PeriodosMateriasResponse Recuperar(int id)
    {
        PeriodoMateria periodoMateria = periodoMateriasServico.Validar(id);

        PeriodosMateriasResponse response = mapper.Map<PeriodosMateriasResponse>(periodoMateria);
        return response;
    }
}
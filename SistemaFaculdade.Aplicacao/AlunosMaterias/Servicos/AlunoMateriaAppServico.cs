using AutoMapper;
using SistemaFaculdade.Aplicacao.AlunosMaterias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Request;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Response;
using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;
using SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Comandos;
using SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.AlunosMaterias.Servicos;

public class AlunoMateriaAppServico : IAlunoMateriaAppServico
{
    private readonly IAlunoMateriaServico alunoMateriaServico;
    private readonly IMapper mapper;

    public AlunoMateriaAppServico(IAlunoMateriaServico alunoMateriaServico, IMapper mapper)
    {
        this.alunoMateriaServico = alunoMateriaServico;
        this.mapper = mapper;
    }

    public AlunoMateriaResponse Atualizar(AlunoMateriaAtualizarRequest aluno)
    {
        AlunoMateriasAtualizarComando alunoMateria = mapper.Map<AlunoMateriasAtualizarComando>(aluno);
        AlunoMateria materia = alunoMateriaServico.Atualizar(alunoMateria);

        AlunoMateriaResponse response = mapper.Map<AlunoMateriaResponse>(materia);
        return response;
    }

    public void Excluir(int id)
    {
        alunoMateriaServico.Excluir(id);
    }

    public AlunoMateriaResponse Inserir(AlunoMateriaInserirRequest aluno)
    {
        AlunoMateriasInserirComando alunoMateria = mapper.Map<AlunoMateriasInserirComando>(aluno);

        AlunoMateria materia = alunoMateriaServico.Inserir(alunoMateria);

        AlunoMateriaResponse response = mapper.Map<AlunoMateriaResponse>(materia);
        return response;
    }

    public AlunoMateriaResponse Recuperar(int id)
    {
        AlunoMateria alunoMateria = alunoMateriaServico.Validar(id);

        AlunoMateriaResponse response = mapper.Map<AlunoMateriaResponse>(alunoMateria);
        return response;
    }
}
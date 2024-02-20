using AutoMapper;
using SistemaFaculdade.Aplicacao.Materias.Servicos.Interfaces;
using SistemaFaculdade.DataTransfer.Materias.Requests;
using SistemaFaculdade.DataTransfer.Materias.Responses;
using SistemaFaculdade.Dominio.Materias.Entidades;
using SistemaFaculdade.Dominio.Materias.Repositorios;
using SistemaFaculdade.Dominio.Materias.Servicos.Interfaces;

namespace SistemaFaculdade.Aplicacao.Materias.Servicos;

public class MateriaAppServico : IMateriaAppServico
{
    private readonly IMateriaServico materiaServico;
    private readonly IMapper mapper;
    private readonly IMateriaRepositorio materiaRepositorio;

    public MateriaAppServico(IMateriaServico materiaServico, IMapper mapper, IMateriaRepositorio materiaRepositorio)
    {
        this.materiaServico = materiaServico;
        this.mapper = mapper;
        this.materiaRepositorio = materiaRepositorio;
    }

    public MateriaResponse Alterar(MateriaAlterarRequest materiaRequest)
    {
        var comando = mapper.Map<Materia>(materiaRequest);
        Materia materia = materiaServico.Atualizar(comando);

        MateriaResponse response = mapper.Map<MateriaResponse>(materia);
        return response;
    }

    public void Deletar(int id)
    {
        Materia materia = materiaServico.Validar(id);
        materiaRepositorio.Remover(materia);
    }

    public MateriaResponse Inserir(MateriaInserirRequest materiaRequest)
    {
        var comando = mapper.Map<Materia>(materiaRequest);
        Materia materia = materiaServico.Inserir(comando);

        MateriaResponse response = mapper.Map<MateriaResponse>(materia);
        return response;
    }

    public IList<MateriaResponse> Listar(MateriaListarRequest materiaRequest)
    {
        IList<Materia> materias = materiaRepositorio.Listar(materiaRequest.Nome);
        IList<MateriaResponse> response = mapper.Map<IList<MateriaResponse>>(materias);
        return response;
    }

    public MateriaResponse Recuperar(int id)
    {
        Materia materia = materiaServico.Validar(id);
        MateriaResponse response = mapper.Map<MateriaResponse>(materia);
        return response;
    }
}
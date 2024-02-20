using SistemaFaculdade.DataTransfer.Materias.Requests;
using SistemaFaculdade.DataTransfer.Materias.Responses;

namespace SistemaFaculdade.Aplicacao.Materias.Servicos.Interfaces;

public interface IMateriaAppServico
{
    MateriaResponse Inserir(MateriaInserirRequest materiaRequest);
    MateriaResponse Recuperar(int id);
    MateriaResponse Alterar(MateriaAlterarRequest materiaRequest);
    void Deletar(int id);
    IList<MateriaResponse> Listar(MateriaListarRequest materiaRequest);
}
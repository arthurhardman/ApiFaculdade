using SistemaFaculdade.Dominio.Ocorrencias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.Ocorrencias.Servicos.Interface;

public interface IOcorrenciaServico
{
    Ocorrencia Inserir(OcorrenciaInserirComando comando);
    Ocorrencia Instanciar(OcorrenciaInserirComando comando);
    Ocorrencia Atualizar(OcorrenciaAlterarComando comando);
    Ocorrencia Validar(int id);
    void Excluir(int id);
}
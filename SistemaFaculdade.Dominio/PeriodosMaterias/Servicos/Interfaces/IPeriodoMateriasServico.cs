using SistemaFaculdade.Dominio.PeriodosMaterias.Entidades;
using SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Comandos;

namespace SistemaFaculdade.Dominio.PeriodosMaterias.Servicos.Interfaces;

public interface IPeriodoMateriasServico
{
    PeriodoMateria Inserir(PeriodosMateriasInserirComando aluno);
    PeriodoMateria Atualizar(PeriodosMateriasAtualizarComando aluno);
    PeriodoMateria Validar(int id);
    PeriodoMateria Instanciar(PeriodosMateriasInserirComando aluno);
    void Excluir(int id);
}
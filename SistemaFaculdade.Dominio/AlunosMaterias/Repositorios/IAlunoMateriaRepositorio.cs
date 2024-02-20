using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;
using SistemaFaculdade.Dominio.Genericos.Repositorio;

namespace SistemaFaculdade.Dominio.AlunosMaterias.Repositorios;

public interface IAlunoMateriaRepositorio : IGenericoRepositorio<AlunoMateria>
{
    IList<AlunoMateria> Listar();
}
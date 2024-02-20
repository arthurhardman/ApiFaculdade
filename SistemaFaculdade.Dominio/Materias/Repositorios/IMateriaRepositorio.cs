using SistemaFaculdade.Dominio.Genericos.Repositorio;
using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.Dominio.Materias.Repositorios;

public interface IMateriaRepositorio : IGenericoRepositorio<Materia>
{
   IList<Materia> Listar(string nome);
}
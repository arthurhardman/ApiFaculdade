using SistemaFaculdade.Dominio.Genericos.Repositorio;
using SistemaFaculdade.Dominio.Professores.Entidades;

namespace SistemaFaculdade.Dominio.Professores.Repositorios;

public interface IProfessorRepositorio : IGenericoRepositorio<Professor>
{
   IList<Professor> Listar(string nome);
}
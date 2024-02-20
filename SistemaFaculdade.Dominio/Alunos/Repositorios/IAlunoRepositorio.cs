using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Genericos.Repositorio;

namespace SistemaFaculdade.Dominio.Alunos.Repositorios;

public interface IAlunoRepositorio : IGenericoRepositorio<Aluno>
{
   IList<Aluno> Listar(string nome);
}
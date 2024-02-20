using SistemaFaculdade.Dominio.Materias.Entidades;

namespace SistemaFaculdade.Dominio.Materias.Servicos.Interfaces;

public interface IMateriaServico
{
    Materia Inserir(Materia comando);
    Materia Instanciar(Materia comando);
    Materia Atualizar(Materia comando);
    Materia Validar(int id);
    void Excluir(int id);
}
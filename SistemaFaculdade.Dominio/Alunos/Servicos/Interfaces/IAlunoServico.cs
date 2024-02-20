using SistemaFaculdade.Dominio.Alunos.Entidades;

namespace SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;

public interface IAlunoServico
{
    Aluno Inserir(Aluno aluno);
    Aluno Atualizar(Aluno aluno);
    Aluno Validar(int matricula);
    Aluno Instanciar(Aluno aluno);
    void Excluir(int id);
}
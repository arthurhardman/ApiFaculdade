using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.AtividadesExtras.Entidades;
using SistemaFaculdade.Dominio.AtividadesExtras.Repositorios;
using SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Comandos;
using SistemaFaculdade.Dominio.AtividadesExtras.Servicos.Interfaces;

namespace SistemaFaculdade.Dominio.AtividadesExtras.Servicos;

public class AtividadeExtraServico : IAtividadeExtraServico
{
    private readonly IAtividadeExtraRepositorio atividadeExtraRepositorio;
    private readonly IAlunoServico alunoServico;

    public AtividadeExtraServico(IAtividadeExtraRepositorio atividadeExtraRepositorio, IAlunoServico alunoServico)
    {
        this.atividadeExtraRepositorio = atividadeExtraRepositorio;
        this.alunoServico = alunoServico;
    }

    public AtividadeExtra Atualizar(AtividadeExtraAlterarComando atividadeExtra)
    {
        AtividadeExtra atividadeExtraExistente = Validar(atividadeExtra.Id);
        Aluno aluno = alunoServico.Validar(atividadeExtra.MatriculaAluno);

        if (!string.IsNullOrEmpty(atividadeExtra.Nome))
        {
            atividadeExtraExistente.SetNome(atividadeExtra.Nome);
        }

        atividadeExtraExistente.SetAluno(aluno);

        atividadeExtraRepositorio.Alterar(atividadeExtraExistente);

        return atividadeExtraExistente;
    }

    public void Excluir(int id)
    {
        AtividadeExtra atividadeExtra = Validar(id);
        atividadeExtraRepositorio.Remover(atividadeExtra);
    }

    public AtividadeExtra Inserir(AtividadeExtraInserirComando atividadeExtra)
    {
        AtividadeExtra atividadeExtras = Instanciar(atividadeExtra);
        return atividadeExtraRepositorio.Inserir(atividadeExtras);
    }

    public AtividadeExtra Instanciar(AtividadeExtraInserirComando atividadeExtra)
    {
        Aluno aluno = alunoServico.Validar(atividadeExtra.MatriculaAluno);
        return new AtividadeExtra(atividadeExtra.Nome, aluno);
    }

    public AtividadeExtra Validar(int id)
    {
        AtividadeExtra atividadeExtra = atividadeExtraRepositorio.Recuperar(id)
        ?? throw new Exception("Atividade Extra inexistente");
        return atividadeExtra;
    }
}
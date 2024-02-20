using SistemaFaculdade.Dominio.Alunos.Entidades;
using SistemaFaculdade.Dominio.Alunos.Servicos.Interfaces;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Repositorios;
using SistemaFaculdade.Dominio.Ocorrencias.Servicos.Comandos;
using SistemaFaculdade.Dominio.Ocorrencias.Servicos.Interface;

namespace SistemaFaculdade.Dominio.Ocorrencias.Servicos
{
    public class OcorrenciaServico : IOcorrenciaServico
    {
        private readonly IOcorrenciaRepositorio ocorrenciaRepositorio;
        private readonly IAlunoServico alunoServico;

        public OcorrenciaServico(IOcorrenciaRepositorio ocorrenciaRepositorio, IAlunoServico alunoServico)
        {
            this.ocorrenciaRepositorio = ocorrenciaRepositorio;
            this.alunoServico = alunoServico;
        }

        public Ocorrencia Atualizar(OcorrenciaAlterarComando comando)
        {
            Ocorrencia ocorrencia = Validar(comando.Id);
            Aluno aluno = alunoServico.Validar(comando.MatriculaAluno);

            ocorrencia.SetDescricao(comando.Descricao);
            ocorrencia.SetAluno(aluno);

            ocorrenciaRepositorio.Alterar(ocorrencia);

            return ocorrencia;
        }

        public void Excluir(int id)
        {
            Ocorrencia ocorrencia = Validar(id);
            ocorrenciaRepositorio.Remover(ocorrencia);
        }

        public Ocorrencia Inserir(OcorrenciaInserirComando comando)
        {
            Ocorrencia ocorrencia = Instanciar(comando);
            return ocorrenciaRepositorio.Inserir(ocorrencia);
        }

        public Ocorrencia Instanciar(OcorrenciaInserirComando comando)
        {
            Aluno aluno = alunoServico.Validar(comando.MatriculaAluno);

            return new Ocorrencia(comando.Descricao, aluno);
        }

        public Ocorrencia Validar(int id)
        {
            Ocorrencia ocorrencia = ocorrenciaRepositorio.Recuperar(id);
            if (ocorrencia == null)
            {
                throw new Exception("A ocorrencia não existe");
            }

            return ocorrencia;
        }
    }
}
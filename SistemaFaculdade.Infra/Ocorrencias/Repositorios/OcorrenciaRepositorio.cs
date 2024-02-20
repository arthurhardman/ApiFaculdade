using NHibernate;
using SistemaFaculdade.Dominio.Ocorrencias.Entidades;
using SistemaFaculdade.Dominio.Ocorrencias.Repositorios;
using SistemaFaculdade.Infra.Genericos;

namespace SistemaFaculdade.Infra.Ocorrencias.Repositorios;

public class OcorrenciaRepositorio : GenericoRepositorio<Ocorrencia>, IOcorrenciaRepositorio
{
    public OcorrenciaRepositorio(ISession session) : base(session) { }
}
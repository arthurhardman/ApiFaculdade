using AutoMapper;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Request;
using SistemaFaculdade.DataTransfer.AlunosMaterias.Response;
using SistemaFaculdade.Dominio.AlunosMaterias.Entidades;
using SistemaFaculdade.Dominio.AlunosMaterias.Servicos.Comandos;

namespace SistemaFaculdade.Aplicacao.AlunosMaterias.Profiles;

public class AlunoMateriaProfile : Profile
{
   public AlunoMateriaProfile()
   {
      CreateMap<AlunoMateria, AlunoMateriaResponse>();
      CreateMap<AlunoMateriaInserirRequest, AlunoMateriasInserirComando>();
      CreateMap<AlunoMateriaAtualizarRequest, AlunoMateriasAtualizarComando>();
   }
}
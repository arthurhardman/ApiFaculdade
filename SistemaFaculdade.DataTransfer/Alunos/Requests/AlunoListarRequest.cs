using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFaculdade.DataTransfer.Alunos.Requests;

public class AlunoListarRequest
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cep { get; set; }
    public string Numero { get; set; }
    public string Adicional { get; set; }
}
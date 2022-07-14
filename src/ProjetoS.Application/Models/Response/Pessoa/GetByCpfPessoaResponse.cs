using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByCpfPessoaResponse : BaseResponse
    {
        public PessoaDto PessoaByCPF { get; set; }
    }
}
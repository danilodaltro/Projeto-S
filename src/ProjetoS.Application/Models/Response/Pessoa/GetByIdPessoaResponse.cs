using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByIdPessoaResponse : BaseResponse
    {
        public PessoaDto PessoaById { get; set; }
    }
}

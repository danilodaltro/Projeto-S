using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByCidadePessoaResponse : BaseResponse
    {
        public List<PessoaDto> PessoasByCidade { get; set; }
    }
}
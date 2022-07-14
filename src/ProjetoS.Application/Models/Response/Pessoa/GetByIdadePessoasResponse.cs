using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByIdadePessoasResponse: BaseResponse
    {
        public List<PessoaDto> PessoasByIdade { get; set; }
    }
}
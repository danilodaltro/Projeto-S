using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetAllPessoasResponse: BaseResponse
    {
        public List<PessoaDto> Pessoas { get; set; }
    }
}

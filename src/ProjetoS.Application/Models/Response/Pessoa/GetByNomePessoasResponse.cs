using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByNomePessoasResponse: BaseResponse
    {
        public List<PessoaDto> PessoasByNome { get; set; }
    }
}
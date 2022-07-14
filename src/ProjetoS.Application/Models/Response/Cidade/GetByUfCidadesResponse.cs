using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByUfCidadesResponse: BaseResponse
    {
        public List<CidadeDto> CidadesByUF { get; set; }
    }
}
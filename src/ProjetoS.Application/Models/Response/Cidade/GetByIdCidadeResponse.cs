using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByIdCidadeResponse : BaseResponse
    {
        public CidadeDto CidadeById { get; set; }
    }
}

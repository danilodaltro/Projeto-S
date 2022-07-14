using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetByNomeCidadesResponse: BaseResponse
    {
        public List<CidadeDto> CidadesByNome { get; set; }
    }
}
using System.Collections.Generic;
using ProjetoS.Application.Common;
using ProjetoS.Application.Models.Dtos;

namespace ProjetoS.Application.Models.Response
{
    public class GetAllCidadesResponse: BaseResponse
    {
        public List<CidadeDto> Cidades { get; set; }
    }
}

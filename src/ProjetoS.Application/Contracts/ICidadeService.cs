using ProjetoS.Application.Models.Request;
using ProjetoS.Application.Models.Response;

namespace ProjetoS.Application.Contracts
{
    public interface ICidadeService
    {
        Task<GetAllCidadesResponse> GetAllAsync();
        Task<GetByIdCidadeResponse> GetByIdAsync(int id);
        Task<GetByNomeCidadesResponse> GetByNomeAsync(string nome);
        Task<GetByUfCidadesResponse> GetByUfAsync(string uf);
        Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request);
        Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request);
        Task<DeleteCidadeResponse> DeleteAsync(int id);
    }
}
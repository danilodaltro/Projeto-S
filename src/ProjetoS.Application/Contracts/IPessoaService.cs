using ProjetoS.Application.Models.Request;
using ProjetoS.Application.Models.Response;

namespace ProjetoS.Application.Contracts
{
    public interface IPessoaService
    {
        Task<GetAllPessoasResponse> GetAllAsync();
        Task<GetByIdPessoaResponse> GetByIdAsync(int id);
        Task<GetByNomePessoasResponse> GetByNomeAsync(string nome);
        Task<GetByCpfPessoaResponse> GetByCPFAsync(string CPF);
        Task<GetByCidadePessoaResponse> GetByCidadeAsync(int idCidade);
        Task<GetByIdadePessoasResponse> GetByIdadeAsync(int idade);
        Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request);
        Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request);
        Task<DeletePessoaResponse> DeleteAsync(int id);
    }
}

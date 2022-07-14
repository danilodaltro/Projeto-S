using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoS.Application.Common;
using ProjetoS.Application.Contracts;
using ProjetoS.Application.Models.Dtos;
using ProjetoS.Application.Models.Request;
using ProjetoS.Application.Models.Response;
using ProjetoS.Domain.Aggregate;
using ProjetoS.Infra.Data;

namespace ProjetoS.Application.Service.PessoaService
{
    public class CidadeService : BaseService<CidadeService>, ICidadeService
    {
        private readonly SqlDbContext _db;

        public CidadeService(ILogger<CidadeService> logger, SqlDbContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request)
        {
            if (request == null)
                throw new ArgumentException("Requisição vazia!");

            var newCidade = Cidade.Create(request.Nome, request.UF);

            _db.Cidade.Add(newCidade);

            await _db.SaveChangesAsync();

            return new CreateCidadeResponse() { Id = newCidade.Id };
        }

        public async Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request)
        {
            if (request == null)
                throw new ArgumentException("Requisição vazia!");

            var entity = await _db.Cidade.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.UF);
                await _db.SaveChangesAsync();
            }

            return new UpdateCidadeResponse();
        }

        public async Task<DeleteCidadeResponse> DeleteAsync(int id)
        {
            var entity = await _db.Cidade.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCidadeResponse();
        }

        public async Task<GetAllCidadesResponse> GetAllAsync()
        {
            var entity = await _db.Cidade.ToListAsync();

            return new GetAllCidadesResponse()
            {
                Cidades = entity != null ? entity.
                                                Select(c => (CidadeDto)c).ToList()
                                        : new List<CidadeDto>()
            };
        }

        public async Task<GetByIdCidadeResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdCidadeResponse();

            var entity = await _db.Cidade.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null) response.CidadeById = (CidadeDto)entity;

            return response;
        }

        public async Task<GetByNomeCidadesResponse> GetByNomeAsync(string nome)
        {
            var response = new GetByNomeCidadesResponse();

            var entity = await _db.Cidade.Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByNomeCidadesResponse()
            {
                CidadesByNome = entity != null ? entity.
                                                    Select(c => (CidadeDto)c).ToList()
                                                : new List<CidadeDto>()
            };
        }

        public async Task<GetByUfCidadesResponse> GetByUfAsync(string uf)
        {
            var response = new GetByUfCidadesResponse();

            var entity = await _db.Cidade.Where(p => p.UF.ToUpper() == uf.ToUpper())
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByUfCidadesResponse()
            {
                CidadesByUF = entity != null ? entity.
                                                    Select(c => (CidadeDto)c).ToList()
                                                : new List<CidadeDto>()
            };
        }
    }
}

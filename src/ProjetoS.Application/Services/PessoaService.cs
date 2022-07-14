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
    public class PessoaService : BaseService<PessoaService>, IPessoaService
    {
        private readonly SqlDbContext _db;

        public PessoaService(ILogger<PessoaService> logger, SqlDbContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPessoasResponse> GetAllAsync()
        {

            var entity = await _db.Pessoa.Include(p => p.Cidade)
                                            .ToListAsync();

            return new GetAllPessoasResponse()
            {
                Pessoas = entity != null ? entity.
                                                Select(p => (PessoaDto)p).ToList()
                                        : new List<PessoaDto>()
            };
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdPessoaResponse();

            var entity = await _db.Pessoa.Include(p => p.Cidade)
                                            .FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null) response.PessoaById = (PessoaDto)entity;

            return response;
        }

        public async Task<GetByNomePessoasResponse> GetByNomeAsync(string nome)
        {
            var response = new GetByNomePessoasResponse();

            var entity = await _db.Pessoa.Include(p => p.Cidade)
                                            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByNomePessoasResponse()
            {
                PessoasByNome = entity != null ? entity.
                                                    Select(p => (PessoaDto)p).ToList()
                                                : new List<PessoaDto>()
            };
        }

        public async Task<GetByCpfPessoaResponse> GetByCPFAsync(string cpf)
        {
            var response = new GetByCpfPessoaResponse();

            var entity = await _db.Pessoa.Include(p => p.Cidade)
                                            .FirstOrDefaultAsync(p => p.CPF == cpf);

            if (entity != null) response.PessoaByCPF = (PessoaDto)entity;

            return response;
        }

        public async Task<GetByCidadePessoaResponse> GetByCidadeAsync(int idCidade)
        {
            var response = new GetByCidadePessoaResponse();

            var entity = await _db.Pessoa.Include(p => p.Cidade)
                                            .Where(p => p.Cidade.Id == idCidade)
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByCidadePessoaResponse()
            {
                PessoasByCidade = entity != null ? entity.
                                                    Select(p => (PessoaDto)p).ToList()
                                                : new List<PessoaDto>()
            };
        }

        public async Task<GetByIdadePessoasResponse> GetByIdadeAsync(int idade)
        {
            var response = new GetByIdadePessoasResponse();

            var entity = await _db.Pessoa.Include(p => p.Cidade)
                                            .Where(p => p.Idade == idade)
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByIdadePessoasResponse()
            {
                PessoasByIdade = entity != null ? entity.
                                                    Select(p => (PessoaDto)p).ToList()
                                                : new List<PessoaDto>()
            };
        }

        public async Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Requisição vazia!");

            var newPessoa = Pessoa.Create(request.Nome, request.CPF, request.IdCidade, request.Idade);

            _db.Pessoa.Add(newPessoa);

            await _db.SaveChangesAsync();

            return new CreatePessoaResponse() { Id = newPessoa.Id };
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Requisição vazia!");

            var entity = await _db.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.CPF, request.IdCidade, request.Idade);
                await _db.SaveChangesAsync();
            }

            return new UpdatePessoaResponse();
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {
            var entity = await _db.Pessoa.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePessoaResponse();
        }
    }
}

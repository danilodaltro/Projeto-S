using ProjetoS.Domain.Aggregate;

namespace ProjetoS.Application.Models.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public CidadeDto Cidade { get; set; }
        public int Idade { get; set; }

        public static explicit operator PessoaDto(Pessoa pessoa)
        {
            return new PessoaDto()
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                CPF = pessoa.CPF,
                Cidade = (CidadeDto)pessoa.Cidade,
                Idade = pessoa.Idade
            };
        }
    }
}

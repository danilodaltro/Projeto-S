using ProjetoS.Domain.Aggregate;

namespace ProjetoS.Application.Models.Dtos
{
    public class CidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public static explicit operator CidadeDto(Cidade cidade)
        {
            return new CidadeDto()
            {
                Id = cidade.Id,
                Nome = cidade.Nome,
                UF = cidade.UF
            };
        }
    }
}

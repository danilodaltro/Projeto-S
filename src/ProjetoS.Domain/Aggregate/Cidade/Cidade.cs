using System.ComponentModel.DataAnnotations;
using ProjetoS.Domain.Aggregate.Exceptions;

namespace ProjetoS.Domain.Aggregate
{
    public sealed class Cidade
    {
        private Cidade(string nome, string uf)
        {
            this.Nome = nome;
            this.UF = uf;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }

        public static Cidade Create(string nome, string uf)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                string errorMessage = string.Format("{0} inválido", nameof(nome));
                errorMessage = char.ToUpper(errorMessage.First()) + errorMessage.Substring(1);
                throw new ArgumentException(errorMessage);
            }
            
            if (string.IsNullOrWhiteSpace(uf))
                throw new ArgumentException(string.Format("{0} inválido", nameof(uf)));

            return new Cidade(nome, uf);
        }

        public void Update(string nome, string uf)
        {
            bool isNomeNullOrWhiteSpace = string.IsNullOrWhiteSpace(nome);
            bool isUFNullOrWhiteSpace = string.IsNullOrWhiteSpace(uf);

            if(!isNomeNullOrWhiteSpace && nome.Length > 200)
                throw new TamanhoExcedidoException(nameof(Nome));

            if (!isUFNullOrWhiteSpace && uf.Length > 2)
                throw new TamanhoExcedidoException(nameof(UF));

            if (!isNomeNullOrWhiteSpace)
                this.Nome = nome;
                
            if (!isUFNullOrWhiteSpace)
                this.UF = uf;
        }
    }
}

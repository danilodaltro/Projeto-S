namespace ProjetoS.Application.Models.Request
{
    public class UpdatePessoaRequest
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int IdCidade { get; set; }
        public int Idade { get; set; }
    }
}

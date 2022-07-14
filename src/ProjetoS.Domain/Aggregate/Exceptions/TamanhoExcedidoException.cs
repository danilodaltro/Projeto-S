namespace ProjetoS.Domain.Aggregate.Exceptions
{
    public class TamanhoExcedidoException : ArgumentException
    {
        public TamanhoExcedidoException(string nameOf) : base(nameOf + " possui tamanho maior que o permitido.")
        {
        }
    }
}
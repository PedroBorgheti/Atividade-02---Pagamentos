using System;

namespace Pagamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pagamento = new PagamentoCartao(Antifraudes.Limite, Cambios.ComTaxa);
            Console.WriteLine(pagamento.Processar());
        }
    }
}

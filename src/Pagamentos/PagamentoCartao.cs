namespace Pagamentos
{
    public sealed class PagamentoCartao : Pagamento
    {
        public PagamentoCartao(System.Func<decimal,bool> antifraude, System.Func<decimal,decimal> cambio)
            : base(antifraude, cambio) { }

        protected override decimal CalcularValorBase() => 120m; // exemplo: taxa/juros base
        protected override bool AutorizarOuCapturar(decimal valor) => true; // simula autorização bem sucedida
        protected override string Confirmar(bool autorizado, decimal valor) => $"Cartão - Autorização: {(autorizado ? "OK" : "NOK")} - {valor:C}";
    }
}

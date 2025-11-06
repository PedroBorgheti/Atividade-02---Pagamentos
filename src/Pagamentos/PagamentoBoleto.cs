namespace Pagamentos
{
    public sealed class PagamentoBoleto : Pagamento
    {
        public PagamentoBoleto(System.Func<decimal,bool> antifraude, System.Func<decimal,decimal> cambio)
            : base(antifraude, cambio) { }

        protected override decimal CalcularValorBase() => 95m; // desconto sobre boleto por exemplo
        // Boleto não autoriza imediatamente; simulamos sempre true
        protected override string Confirmar(bool autorizado, decimal valor) => $"Boleto - Instruções geradas (linha digitável) - {valor:C}";
    }
}

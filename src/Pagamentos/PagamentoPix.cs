namespace Pagamentos
{
    public sealed class PagamentoPix : Pagamento
    {
        public PagamentoPix(System.Func<decimal,bool> antifraude, System.Func<decimal,decimal> cambio)
            : base(antifraude, cambio) { }

        protected override decimal CalcularValorBase() => 100m; // valor base
        protected override bool AutorizarOuCapturar(decimal valor) => true; // PIX normalmente não autoriza, mas confirma
        protected override string Confirmar(bool autorizado, decimal valor) => $"PIX - QR gerado e confirmado - {valor:C}";
    }
}

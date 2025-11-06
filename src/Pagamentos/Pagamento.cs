using System;

namespace Pagamentos
{
    public class Pagamento
    {
        private readonly Func<decimal, bool> _antifraude;
        private readonly Func<decimal, decimal> _cambio;

        public Pagamento(Func<decimal, bool> antifraude, Func<decimal, decimal> cambio)
        {
            _antifraude = antifraude ?? (v => true);
            _cambio = cambio ?? (v => v);
        }

        public string Processar()
        {
            Validar();

            var subtotal = CalcularValorBase();
            // aplicar cambio primeiro (ex.: conversão de moeda)
            var convertido = _cambio(subtotal);

            // antifraude avalia o valor convertido
            if (!_antifraude(convertido))
                return EmitirReciboRejeitado(convertido);

            var autorizado = AutorizarOuCapturar(convertido);
            return Confirmar(autorizado, convertido);
        }

        protected virtual void Validar()
        {
            // validação mínima por padrão
        }

        protected virtual decimal CalcularValorBase() => 100m;

        protected virtual bool AutorizarOuCapturar(decimal valor) => true;

        protected virtual string Confirmar(bool autorizado, decimal valor) => $"Comprovante: {(autorizado ? "Pago" : "Falha")} - {valor:C}";

        protected virtual string EmitirReciboRejeitado(decimal valor) => $"Pagamento rejeitado por antifraude - {valor:C}";
    }
}

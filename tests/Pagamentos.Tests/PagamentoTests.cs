using Xunit;

namespace Pagamentos.Tests
{
    public class PagamentoTests
    {
        [Fact]
        public void LSP_Processar_DeveFuncionarComTodosOsTiposSemDowncast()
        {
            string ProcessarPagamento(Pagamento p) => p.Processar();

            var cartao = new PagamentoCartao(Antifraudes.SempreAprova, Cambios.SemCambio);
            var pix = new PagamentoPix(Antifraudes.SempreAprova, Cambios.SemCambio);
            var boleto = new PagamentoBoleto(Antifraudes.SempreAprova, Cambios.SemCambio);

            var r1 = ProcessarPagamento(cartao);
            var r2 = ProcessarPagamento(pix);
            var r3 = ProcessarPagamento(boleto);

            Assert.Contains("Cartão", r1);
            Assert.Contains("PIX", r2);
            Assert.Contains("Boleto", r3);
        }

        [Fact]
        public void Composicao_TrocaDePoliticas_DeveAlterarResultadoSemNovasSubclasses()
        {
            var p1 = new PagamentoCartao(Antifraudes.SempreAprova, Cambios.SemCambio);
            var p2 = new PagamentoCartao(Antifraudes.SempreAprova, Cambios.ComTaxa);

            var r1 = p1.Processar();
            var r2 = p2.Processar();

            Assert.NotEqual(r1, r2);
        }

        [Fact]
        public void Antifraude_RejeitaPagamento()
        {
            var p = new PagamentoPix(Antifraudes.Limite, Cambios.SemCambio); // limite <=200
            // usando cambio com taxa para aumentar valor e possivelmente rejeitar
            var p2 = new PagamentoPix(v => false, Cambios.ComTaxa);

            var r1 = p.Processar();
            var r2 = p2.Processar();

            Assert.DoesNotContain("rejeitado", r1.ToLower()); // p normalmente aprovado
            Assert.Contains("rejeitado", r2.ToLower());
        }
    }
}

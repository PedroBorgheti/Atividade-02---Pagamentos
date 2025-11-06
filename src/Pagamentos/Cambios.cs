namespace Pagamentos
{
    public static class Cambios
    {
        public static decimal SemCambio(decimal valor) => valor;
        public static decimal ComTaxa(decimal valor) => valor * 1.02m; // aplicação de taxa de 2%
    }
}

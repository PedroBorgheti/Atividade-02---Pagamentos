namespace Pagamentos
{
    public static class Antifraudes
    {
        public static bool SempreAprova(decimal valor) => true;
        public static bool Limite(decimal valor) => valor <= 200m;
    }
}

namespace UnitTests.Calculadora
{
    public class Calculadora
    {
        public int Dividir(int a, int b, out int resto)
        {
            resto = a % b;

            return a / b;
        }
    }
}

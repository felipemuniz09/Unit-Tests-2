using Xunit;

namespace UnitTests.Calculadora
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Dividir_Sucesso()
        {
            // Arrange
            var calculadora = new Calculadora();
            int resto;

            // Act
            var resultado = calculadora.Dividir(20, 7, out resto);

            // Assert
            Assert.Equal(2, resultado);
            Assert.Equal(6, resto);
        }
    }
}

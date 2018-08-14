using AutoMoq;
using Moq;
using System;
using Xunit;

namespace UnitTests.Exemplo2
{
    public class ContaCorrenteServicoTests
    {
        private readonly ContaCorrenteServico _contaCorrenteServico;
        private readonly Mock<IContaCorrenteRepositorio> _contaCorrenteRepositorio;

        public ContaCorrenteServicoTests()
        {
            var mocker = new AutoMoqer();

            _contaCorrenteServico = mocker.Resolve<ContaCorrenteServico>();

            _contaCorrenteRepositorio = mocker.GetMock<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void ContaCorrenteServico_RealizarTransferencia_SaldoInsuficiente()
        {
            // Arrange
            var origem = new ContaCorrente { Banco = 33, Agencia = 3582, Numero = 03380384 };

            _contaCorrenteRepositorio
                .Setup(c => c.Recuperar(origem.Banco, origem.Agencia, origem.Numero))
                .Returns(new ContaCorrente { Banco = 33, Agencia = 3582, Numero = 03380384, Saldo = 99 });

            _contaCorrenteRepositorio
                .Setup(c => c.Salvar(It.IsAny<ContaCorrente>()));

            // Act
            var exception = Assert.Throws<Exception>(() => _contaCorrenteServico.RealizarTransferencia(origem, 100));

            // Assert
            Assert.Equal("Saldo insuficiente.", exception.Message);
        }

        [Fact]
        public void ContaCorrenteServico_RealizarTransferencia_AtualizouSaldoContaOrigem()
        {
            // Arrange
            var origem = new ContaCorrente { Banco = 33, Agencia = 3582, Numero = 03380384 };

            _contaCorrenteRepositorio
                .Setup(c => c.Recuperar(origem.Banco, origem.Agencia, origem.Numero))
                .Returns(new ContaCorrente { Banco = 33, Agencia = 3582, Numero = 03380384, Saldo = 101 });

            _contaCorrenteRepositorio
                .Setup(c => c.Salvar(It.IsAny<ContaCorrente>()));

            // Act
            _contaCorrenteServico.RealizarTransferencia(origem, 100);

            // Assert
            _contaCorrenteRepositorio.Verify(c => c.Salvar(It.IsAny<ContaCorrente>()), Times.Once());
        }
    }
}

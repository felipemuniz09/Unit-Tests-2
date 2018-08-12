using AutoMoq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Fact(DisplayName = "ContaCorrenteServico - RealizarTransferencia - Saldo insuficiente")]
        public void ContaCorrenteServico_RealizarTransferencia_SaldoInsuficiente()
        {
            // Arrange
            var origem = new ContaCorrente { Banco = 33, Agencia = 3582, Numero = 03380384 };
            var destino = new ContaCorrente { Banco = 33, Agencia = 3784, Numero = 09002879 };

            _contaCorrenteRepositorio
                .Setup(c => c.Recuperar(origem.Banco, origem.Agencia, origem.Numero))
                .Returns(new ContaCorrente { Banco = 33, Agencia = 3582, Numero = 03380384, Saldo = 99 });

            _contaCorrenteRepositorio
                .Setup(c => c.Recuperar(destino.Banco, destino.Agencia, destino.Numero))
                .Returns(new ContaCorrente { Banco = 33, Agencia = 3784, Numero = 09002879, Saldo = 200 });

            _contaCorrenteRepositorio
                .Setup(c => c.Salvar(It.IsAny<ContaCorrente>()));

            // Act
            var exception = Assert.Throws<Exception>(() => _contaCorrenteServico.RealizarTransferencia(origem, destino, 100));

            // Assert
            Assert.Equal("Saldo insuficiente.", exception.Message);
        }
    }
}

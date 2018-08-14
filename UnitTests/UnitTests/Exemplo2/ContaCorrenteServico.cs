using System;

namespace UnitTests.Exemplo2
{
    public class ContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteServico(IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        public void RealizarTransferencia(ContaCorrente origem, decimal valor)
        {
            var origemBD = _contaCorrenteRepositorio.Recuperar(origem.Banco, origem.Agencia, origem.Numero);

            if (origemBD.Saldo < valor)
                throw new Exception("Saldo insuficiente.");

            origemBD.EnviarTransferencia(valor);

            _contaCorrenteRepositorio.Salvar(origemBD);
        }
    }
}

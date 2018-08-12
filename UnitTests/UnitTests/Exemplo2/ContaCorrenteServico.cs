using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Exemplo2
{
    public class ContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteServico(IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        public void RealizarTransferencia(ContaCorrente origem, ContaCorrente destino, decimal valor)
        {
            var origemBD = _contaCorrenteRepositorio.Recuperar(origem.Banco, origem.Agencia, origem.Numero);

            var destinoBD = _contaCorrenteRepositorio.Recuperar(destino.Banco, destino.Agencia, destino.Numero);

            if (origemBD.Saldo < valor)
                throw new Exception("Saldo insuficiente.");

            origemBD.EnviarTransferencia(valor);

            destinoBD.ReceberTransferencia(valor);

            _contaCorrenteRepositorio.Salvar(origemBD);

            _contaCorrenteRepositorio.Salvar(destinoBD);
        }
    }
}

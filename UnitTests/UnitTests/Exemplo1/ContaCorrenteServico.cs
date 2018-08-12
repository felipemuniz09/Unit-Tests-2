using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Exemplo1
{
    public class ContaCorrenteServico
    {
        public void RealizarTransferencia(ContaCorrente origem, ContaCorrente destino, decimal valor)
        {
            var contaCorrenteRepositorio =
                new ContaCorrenteRepositorio(@"Data Source=.\SQLExpress;User Instance=true;Integrated Security=true;AttachDbFilename=|DataDirectory|DataBaseName.mdf;");

            var origemBD = contaCorrenteRepositorio.Recuperar(origem.Banco, origem.Agencia, origem.Numero);

            var destinoBD = contaCorrenteRepositorio.Recuperar(destino.Banco, destino.Agencia, destino.Numero);

            if (origemBD.Saldo < valor)
                throw new Exception("Saldo insuficiente.");

            origemBD.EnviarTransferencia(valor);

            destinoBD.ReceberTransferencia(valor);

            contaCorrenteRepositorio.Salvar(origemBD);

            contaCorrenteRepositorio.Salvar(destinoBD);
        }
    }
}

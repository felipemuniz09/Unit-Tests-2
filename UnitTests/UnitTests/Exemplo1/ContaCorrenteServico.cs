using System;

namespace UnitTests.Exemplo1
{
    public class ContaCorrenteServico
    {
        public void RealizarTransferencia(ContaCorrente origem, decimal valor)
        {
            var contaCorrenteRepositorio = 
                new ContaCorrenteRepositorio(@"AttachDbFilename=|DataDirectory|DataBaseName.mdf;");

            var origemBD = contaCorrenteRepositorio.Recuperar(origem.Banco, origem.Agencia, origem.Numero);

            if (origemBD.Saldo < valor)
                throw new Exception("Saldo insuficiente.");

            origemBD.EnviarTransferencia(valor);

            contaCorrenteRepositorio.Salvar(origemBD);
        }
    }
}

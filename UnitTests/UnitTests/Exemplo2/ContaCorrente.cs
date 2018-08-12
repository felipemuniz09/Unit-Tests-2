using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Exemplo2
{
    public class ContaCorrente
    {
        public int Banco { get; set; }

        public int Agencia { get; set; }

        public int Numero { get; set; }

        public decimal Saldo { get; set; }

        public void EnviarTransferencia(decimal valor)
        {
            Saldo = Saldo - valor;
        }

        public void ReceberTransferencia(decimal valor)
        {
            Saldo = Saldo + valor;
        }
    }
}

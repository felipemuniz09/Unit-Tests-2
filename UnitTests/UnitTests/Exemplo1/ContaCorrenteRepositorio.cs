using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Exemplo1
{
    public class ContaCorrenteRepositorio
    {
        public ContaCorrenteRepositorio(string connectionString)
        {

        }

        public ContaCorrente Recuperar(int banco, int agencia, int numero)
        {
            return new ContaCorrente();
        }

        public void Salvar(ContaCorrente contaCorrente)
        {

        }
    }
}

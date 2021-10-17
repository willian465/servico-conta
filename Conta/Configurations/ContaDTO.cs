using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Configurations
{
    public class ContaDTO
    {
        public long Numero { get; set; }
        public int Digito { get; set; }
        public int CodigoCliente { get; set; }
        public double Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool Ativa { get; set; }
    }
}

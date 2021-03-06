using System;

namespace Conta.Configurations
{
    public class ContaDTO
    {
        public long Numero { get; set; }
        public int Digito { get; set; }
        public int CodigoCliente { get; set; }
        public double Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public string DataAberturaTratada { get; set; }
        public bool Ativa { get; set; }
        public string SaldoTratado { get; set; }
    }
}

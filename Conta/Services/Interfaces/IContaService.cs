using Conta.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Services.Interfaces
{
    public interface IContaService
    {
        /// <summary>
        /// Método para criar uma conta
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <returns></returns>
        Task<ContaResponse> CriarConta(int codigoCliente);
        /// <summary>
        /// Método para realizar um saque
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroConta"></param>
        /// <param name="valorSaque"></param>
        /// <returns></returns>
        Task<bool> Sacar(int numeroConta, double valorSaque);
        /// <summary>
        /// Método para realizar um depósito
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroConta"></param>
        /// <param name="valorDeposito"></param>
        /// <returns></returns>
        Task<bool> Depositar(int numeroConta, double valorDeposito);
        /// <summary>
        /// Método para buscar a conta do cliente
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <returns></returns>
        Task<ContaResponse> BuscarConta(long codigoCliente);
    }
}

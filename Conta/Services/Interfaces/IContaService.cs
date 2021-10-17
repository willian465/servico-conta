using Conta.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Services.Interfaces
{
    public interface IContaService
    {
        Task<ContaResponse> CriarConta(int codigoCliente);
        Task Depositar(int numeroConta);
        Task Sacar(int numeroConta);
    }
}

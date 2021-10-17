using Conta.Responses;
using Conta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Services
{
    public class ContaService : IContaService
    {
        public Task<ContaResponse> CriarConta(int codigoCliente)
        {
            throw new NotImplementedException();
        }

        public Task Depositar(int numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task Sacar(int numeroConta)
        {
            throw new NotImplementedException();
        }
    }
}

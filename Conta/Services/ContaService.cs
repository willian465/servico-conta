using Conta.Exceptions;
using Conta.Mapper;
using Conta.Models;
using Conta.Repositories.Interfaces;
using Conta.Responses;
using Conta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Services
{
    public class ContaService : IContaService
    {
        private readonly IMemoryRepository _memoryRepository;
        private readonly IConverter _converter;

        public ContaService(IMemoryRepository memoryRepository,
                            IConverter converter)
        {
            _memoryRepository = memoryRepository;
            _converter = converter;
        }
        public async Task<ContaResponse> CriarConta(int codigoCliente)
        {
            if (codigoCliente <= 0)
                throw new ContaException("O código do cliente é obrigatório");

            ContaModel contaCadastrada = _memoryRepository.Buscar<ContaModel>(codigoCliente.ToString());

            if(contaCadastrada != null)
                throw new ContaException("Cliente já possui conta cadastrada");

            ContaModel conta = new ContaModel()
            {
                Numero = new Random(DateTime.Now.Millisecond).Next(),
                Digito = 1,
                CodigoCliente = codigoCliente,
                Saldo = 0.0,
                DataAbertura = DateTime.Now,
                Ativa = true
            };

            ContaModel contaSalvaModel = await _memoryRepository.Adicionar(conta, codigoCliente.ToString());

            // eu faria essa conversão direto no campo da classe, mas como pediu um método
            contaSalvaModel.DataAberturaTratada = DateTimeConvertAsString(contaSalvaModel.DataAbertura);

            return _converter.Map<ContaResponse>(contaSalvaModel);
        }

        public Task Depositar(int numeroConta)
        {
            throw new NotImplementedException();
        }

        public Task Sacar(int numeroConta)
        {
            throw new NotImplementedException();
        }

        private string DateTimeConvertAsString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}

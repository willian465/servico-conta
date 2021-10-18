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

        public async Task<ContaResponse> BuscarConta(long numeroConta)
        {
            if (numeroConta <= 0)
                throw new ContaException("O código do cliente é obrigatório");

            ContaModel contaCadastrada = await _memoryRepository.Buscar<ContaModel>(numeroConta.ToString());

            if (contaCadastrada != null)
            {
                contaCadastrada.DataAberturaTratada = DateTimeConvertAsString(contaCadastrada.DataAbertura);
                contaCadastrada.SaldoTratado = ConvertToMoney(contaCadastrada.Saldo);
                return _converter.Map<ContaResponse>(contaCadastrada);
            }
            return null;
        }

        public async Task<ContaResponse> CriarConta(int codigoCliente)
        {
            if (codigoCliente <= 0)
                throw new ContaException("O código do cliente é obrigatório");

            ContaModel contaCadastrada = await _memoryRepository.Buscar<ContaModel>(codigoCliente.ToString());

            if (contaCadastrada != null)
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

            ContaModel contaSalvaModel = await _memoryRepository.Adicionar(conta, conta.Numero.ToString());

            // eu faria essa conversão direto no campo da classe, mas como pediu um método
            contaSalvaModel.DataAberturaTratada = DateTimeConvertAsString(contaSalvaModel.DataAbertura);
            contaSalvaModel.SaldoTratado = ConvertToMoney(contaSalvaModel.Saldo);

            return _converter.Map<ContaResponse>(contaSalvaModel);
        }

        public async Task<bool> Depositar(int numeroConta, double valorDeposito)
        {
            if (numeroConta <= 0)
                throw new ContaException("O número da conta é obrigatório");

            if (valorDeposito < 0)
                throw new ContaException("O valor do depósito deve ser maior que zero");

            // busca a conta informada
            ContaModel contaCadastrada = await _memoryRepository.Buscar<ContaModel>(numeroConta.ToString());

            if (contaCadastrada == null)
                throw new ContaException("Conta não encontrada");

            contaCadastrada.Saldo += valorDeposito;

            await _memoryRepository.Atualizar(contaCadastrada, numeroConta.ToString());

            return true;
        }

        public async Task<bool> Sacar(int numeroConta, double valorSaque)
        {
            if (numeroConta <= 0)
                throw new ContaException("O número da conta é obrigatório");

            if (valorSaque < 0)
                throw new ContaException("O valor do saque deve ser maior que zero");

            // busca a conta informada
            ContaModel contaCadastrada = await _memoryRepository.Buscar<ContaModel>(numeroConta.ToString());

            if (contaCadastrada == null || !contaCadastrada.Ativa)
                throw new ContaException("Cliente não possui conta");

            if (contaCadastrada.Numero != numeroConta)
                throw new ContaException("Cliente não possui a conta informada");

            if ((contaCadastrada.Saldo - valorSaque) < 0)
                throw new ContaException("Cliente não possui o valor disponível para saque");

            // atualiza o saldo
            contaCadastrada.Saldo -= valorSaque;

            await _memoryRepository.Atualizar(contaCadastrada, numeroConta.ToString());

            return true;
        }

        private string DateTimeConvertAsString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private string ConvertToMoney(double value)
        {
            //return string.Format("R$ {0}", Convert.ToDecimal(value));
            return string.Format("R$ {0:n}", value);
        }
    }
}

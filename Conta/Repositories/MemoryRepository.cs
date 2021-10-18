using Conta.Models;
using Conta.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conta.Repositories
{
    /// <summary>
    /// Classe de centralizar o uso do cache
    /// </summary>
    public class MemoryRepository : IMemoryRepository
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<T> Buscar<T>(string key)
        {
            return Task.FromResult(_memoryCache.Get<T>(key));
        }

        public Task<T> Adicionar<T>(T model, string key)
        {
            return Task.FromResult(_memoryCache.Set(key, model));
        }

        public void Remover(string key)
        {
            _memoryCache.Remove(key);
        }
        public Task Atualizar<T>(T model, string key)
        {
            _memoryCache.Remove(key);
            return Task.FromResult(_memoryCache.Set(key, model));
        }

        public void CarregarBase()
        {

            List<ContaModel> contasMock = new List<ContaModel>()
            {

               new ContaModel()
               {
                    Numero = 940400278,
                    Digito = 1,
                    CodigoCliente = 1,
                    Saldo = 0.0,
                    DataAbertura = DateTime.Now,
                    Ativa = true
               },
               new ContaModel()
               {
                    Numero = 116711019,
                    Digito = 1,
                    CodigoCliente = 2,
                    Saldo = 0.0,
                    DataAbertura = DateTime.Now,
                    Ativa = true
               },
                new ContaModel()
                {
                    Numero = 395625934,
                    Digito = 1,
                    CodigoCliente = 3,
                    Saldo = 0.0,
                    DataAbertura = DateTime.Now,
                    Ativa = true
                }
            };

            // carregando o mock
            contasMock.ForEach(x => _memoryCache.Set(x.Numero.ToString(), x));
        }

    }
}

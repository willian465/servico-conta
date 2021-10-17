using Conta.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
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

        public T Buscar<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public Task<T> Adicionar<T>(T model, string key)
        {
            return Task.FromResult(_memoryCache.Set(key, model));
        }

        public void Remover(string key)
        {
            _memoryCache.Remove(key);
        }
        public T Atualizar<T>(T model, string key)
        {
            _memoryCache.Remove(key);
            return _memoryCache.Set(key, model);
        }
    }
}

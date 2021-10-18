using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Repositories.Interfaces
{
    public interface IMemoryRepository
    {
        void Remover(string key);
        Task<T> Adicionar<T>(T model, string key);
        Task<T> Buscar<T>(string key);
        Task Atualizar<T>(T model, string key);
        void CarregarBase();
    }
}

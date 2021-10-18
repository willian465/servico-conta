using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Mappers
{
    public interface IConverter
    {
        T Map<T>(object source);
    }
}

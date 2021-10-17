using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conta.Exceptions
{
    public class ContaException : Exception
    {
        public ContaException(string message) : base(message) 
        {
        }
    }
}

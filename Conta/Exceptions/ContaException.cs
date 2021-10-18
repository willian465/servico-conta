using System;

namespace Conta.Exceptions
{
    public class ContaException : Exception
    {
        public ContaException(string message) : base(message)
        {
        }
    }
}

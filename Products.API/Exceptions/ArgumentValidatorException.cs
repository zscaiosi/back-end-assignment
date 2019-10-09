using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Exceptions
{
    public class ArgumentValidatorException : ArgumentException
    {
        public ArgumentValidatorException(string message) : base(message) { }
        public ArgumentValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}

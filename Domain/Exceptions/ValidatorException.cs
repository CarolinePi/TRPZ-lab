using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    class ValidatorException: Exception
    {
        public ValidatorException(string message) : base(message) { }
    }
}

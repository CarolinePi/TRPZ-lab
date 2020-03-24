using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Validators
{
    public class FieldValidator
    {
        public static void AssertFieldIsValid(string number_of_string)
        {
            if (number_of_string.All(char.IsDigit))
            {
                throw new ValidatorException("Given string is not numeric.");
            }
        }
    }
}

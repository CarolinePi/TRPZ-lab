using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Validators
{
    public class FieldValidator
    {
        public static void AssertFieldIsValid(int number)
        {
            if (number <= 0)
            {
                throw new ValidatorException("Given number <= 0.");
            }
        }
    }
}

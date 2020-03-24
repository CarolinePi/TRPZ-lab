using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validators
{
    public class FrameValidator
    {
        public static void AssertFrameIsValid(Frame frame)
        {
            if (frame == null)
            {
                throw new ValidatorException("Choose what frame will be added.");
            }
        }
    }
}

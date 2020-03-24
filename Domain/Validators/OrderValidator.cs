using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Validators
{
    public class OrderValidator
    {
        public static void AssertOrderIsValid(Order order)
        {
            if (!order.OrderItems.Any())
            {
                throw new ValidatorException("Order can't be empty.");
            }
        }

    }
}

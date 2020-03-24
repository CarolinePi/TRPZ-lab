using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validators
{
    public class OrderItemValidator
    {
        public static void AssertOrderItemIsValid(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ValidatorException("Choose what frame will be removed.");
            }
        }

        public static void AssertOrderItemsIsValid(IList<OrderItem> orderItems)
        {
            if (orderItems is null)
            {
                throw new ValidatorException("First add frames if you want to remove smth)");
            }
        }
    }
}

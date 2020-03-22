using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Order
    {
        public IList<OrderItem> OrderItems = new List<OrderItem>();
    }
}

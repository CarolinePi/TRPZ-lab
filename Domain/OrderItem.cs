using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderItem
    {
        public Frame Frame { get; set; }
        public int Quantity { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public OrderItem()
        {
        }
                   

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class OrderItem
    {
        public Frame Frame { get; set; }
        public int Quantity { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public OrderItem(Frame frame, int quantity, int width, int height)
        {
            this.Frame = frame;
            this.Quantity = quantity;
            this.Width = width;
            this.Height = height;
        }
                   

    }
}

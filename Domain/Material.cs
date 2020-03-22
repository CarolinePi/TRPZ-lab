using System;
using System.Collections.Generic;
using System.Text;


namespace Domain
{
    class Material
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Material(string Name, int Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
        }
    }
}

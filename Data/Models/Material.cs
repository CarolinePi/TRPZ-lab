using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Material : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

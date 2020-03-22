using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Frame : BaseModel
    {
        public string Name { get; set; }
        public IList<Material> Materials { get; set; }
    }
}

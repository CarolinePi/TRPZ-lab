using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Frame
    {
        public string Name { get; set; }
        public IList<Material> Materials { get; set; }

        public Frame(string name, List<Material> Materials)
        {
            this.Name = name;
            this.Materials = Materials;
        }
    }

}


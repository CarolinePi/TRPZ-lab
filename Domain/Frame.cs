using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Frame
    {
        public string Name { get; set; }
        public IList<Material> Materials { get; set; }

        public Frame()
        {
        }
    }

}


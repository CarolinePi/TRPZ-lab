using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Frame
    {
        public string Name { get; set; }
        public IList<string> Materials { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Frame(string name, List<string> Materials, int Width, int Height)
        {
            this.Name = name;
            this.Materials = Materials;
            this.Width = Width;
            this.Height = Height;
        }
    }

}


using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class FrameModel : BaseModel
    {
        public string Name { get; set; }
        public IList<MaterialModel> Materials { get; set; }
    }
}

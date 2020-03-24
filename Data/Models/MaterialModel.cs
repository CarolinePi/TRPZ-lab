using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class MaterialModel : BaseModel
    {
        public string Name { get; set; }
        
        public int Quantity { get; set; }

        public Guid FrameModelId { get; set; }
        public FrameModel FrameModel {get; set;}
    }
}

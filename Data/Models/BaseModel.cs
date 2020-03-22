using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public Guid Id { get; set; }
    }
}

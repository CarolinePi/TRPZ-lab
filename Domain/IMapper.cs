using Data.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMapper<FromType, ToType>
    {
        ToType Map(FromType t);
        FromType ReverseMap(ToType t);
    }
}

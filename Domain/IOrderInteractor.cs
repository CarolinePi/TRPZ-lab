using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    interface IOrderInteractor
    {
        IList<Material> CountOrderMaterials(Order order);
    }
}

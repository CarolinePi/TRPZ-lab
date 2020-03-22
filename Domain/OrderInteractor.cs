using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class OrderInteractor : IOrderInteractor
    {
        public IList<Material> CountOrderMaterials(Order o)
        {
            IDictionary<string, Material> dictMaterial = new Dictionary<string, Material>();
            foreach (OrderItem orderItem in o.OrderItems)
            {
                foreach (Material material in orderItem.Frame.Materials)
                {
                    if (dictMaterial.TryGetValue(material.Name, out Material totalMaterial))
                    {
                        totalMaterial.Quantity += orderItem.Height * orderItem.Width * orderItem.Quantity * material.Quantity;
                    }
                    else
                    {
                        totalMaterial = new Material(material.Name, orderItem.Height * orderItem.Width * orderItem.Quantity * material.Quantity);
                        dictMaterial[totalMaterial.Name] = totalMaterial;
                    }
                }
            }

            IList<Material> materials = new List<Material>();
            foreach (var material in dictMaterial)
            {
                materials.Add(material.Value);
            }
            return materials;
        }
    }
}

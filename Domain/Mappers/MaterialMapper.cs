using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappers
{
    public class MaterialMapper : IMapper<IEnumerable<Material>, IEnumerable<MaterialModel>>
    {
        IEnumerable<MaterialModel> IMapper<IEnumerable<Material>, IEnumerable<MaterialModel>>.Map(IEnumerable<Material> materials)
        {
            List<MaterialModel> l = new List<MaterialModel>();
            foreach (Material m in materials)
            {
                var materialModel = new MaterialModel
                {
                    Name = m.Name,
                    Quantity = m.Quantity
                };
                l.Add(materialModel);
            }
            return l;
        }

        IEnumerable<Material> IMapper<IEnumerable<Material>, IEnumerable<MaterialModel>>.ReverseMap(IEnumerable<MaterialModel> materials)
        {
            List<Material> l = new List<Material>();
            foreach (MaterialModel m in materials)
            {
                var material = new Material
                {
                    Name = m.Name,
                    Quantity = m.Quantity
                };
                l.Add(material);
            }
            return l;
        }
    }
}

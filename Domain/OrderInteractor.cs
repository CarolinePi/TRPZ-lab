using Domain.Exceptions;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderInteractor : IOrderInteractor
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
                        totalMaterial = new Material();
                        totalMaterial.Name = material.Name;
                        totalMaterial.Quantity = orderItem.Height * orderItem.Width * orderItem.Quantity * material.Quantity;
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

        public void AddOrderItem(Order order, Frame frame, int quantity, int width, int height)
        {
            OrderItem orderItem = new OrderItem
            {
                Frame = frame,
                Quantity = quantity,
                Width = width,
                Height = height
            };
            order.OrderItems.Add(orderItem);
        }
        public void CreateOrder(Order order)
        {
            try
            {
                OrderValidator.AssertOrderIsValid(order);
            }
            catch (ValidatorException e)
            {
                Console.WriteLine(e.Message);
            }
            CountOrderMaterials(order);
        }

    }
}

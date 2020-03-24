using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IOrderInteractor
    {
        IList<Material> CountOrderMaterials(Order order);
        void AddOrderItem(Order order, Frame frame, int quantity, int wight, int height);
        void DeleteOrderItem(Order order, OrderItem orderItem);
        void CreateOrder(Order order);
        IList<OrderItem> GetOrderItems(Order order);
    }
}

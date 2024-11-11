using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class Store
    {
        public CustomerRepository CustomerRepository { get; private set; } = new CustomerRepository();
        public PizzaRepository PizzaRepository { get; private set; } = new PizzaRepository();
        public List<Order> Orders { get; private set; } = new List<Order>();

        public void AddOrder(Order nweOrder)
        {
            Orders.Add(nweOrder);
        }

        public Order GetOrder(int id)
        {
            foreach (Order order in Orders)
                if (order.Id == id) return order;
            return null;
        }

        public List<Order> GetAllOrders()
        {
            return Orders;
        }

        public Order DeleteOrder(int id)
        {
            foreach (Order order in Orders)
            {
                if (order.Id == id)
                {
                    Orders.Remove(order);
                    return order;
                }
            }

            return null;
        }


    }
}

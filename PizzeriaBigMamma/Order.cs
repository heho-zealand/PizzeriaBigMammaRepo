using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class Order
    {
        private static int nextId = 1;
        public int Id { get; private set; }
        public Customer Customer { get; private set; }

        public DateTime OrderDate { get; set; }
        public bool ToBeDelivered { get; set; }

        private List<OrderItem> _orderItems = new List<OrderItem>();

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }

        public double CalculatePrice()
        {
            double price = 0;
            foreach (OrderItem orderItem in _orderItems)
            {
                price += orderItem.CalculatePrice();
            }
            return price;
        }

        public Order() { Id = nextId++; }

        public Order(Customer customer, bool toBeDelivered)
        {
            Id = nextId++;
            Customer = customer;
            OrderDate = DateTime.Now;
            ToBeDelivered = toBeDelivered;
        }

        public string PrintOrder()
        {
            String order = $"Ordre # {Id} Dato/Tid: {OrderDate} Levering: {!ToBeDelivered}\n";

            if (ToBeDelivered) order += $"Kunde: {Customer.Name}, {Customer.Address}, Tlf: {Customer.Phone} \n";

            foreach (OrderItem orderItem in _orderItems)
            {
                order += $"{orderItem.Number} stk {orderItem.Pizza}";
                if (orderItem.Toppings != null)
                    foreach (ExtraTopping ext in orderItem.Toppings)
                        order += $"+ {ext.Name} af {ext.Price} kr. ";
                order += $"Pris: {orderItem.CalculatePrice()} kr.\n";
            }
            order += $"Pris ialt: {CalculatePrice()} kr.";
            return order;
        }
    }
}

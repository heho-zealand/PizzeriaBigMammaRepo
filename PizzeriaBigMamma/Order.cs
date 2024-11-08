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

        public void PrintOrder()
        {
            Console.WriteLine("Ordre #" + Id + " Dato/Tid: " + OrderDate + " Levering: " + !ToBeDelivered);
            if (ToBeDelivered) Console.WriteLine("Kunde: " + Customer.Name + ", " + Customer.Address + ", Tlf: " + Customer.Phone);
            foreach (OrderItem orderItem in _orderItems)
            {
                Console.Write(orderItem.Number + " stk " + orderItem.Pizza);
                if (orderItem.Toppings != null)
                    foreach (ExtraTopping ext in orderItem.Toppings)
                        Console.Write("+ " + ext.Name + " af " + ext.Price + "kr. ");
                Console.WriteLine(" pris: " + orderItem.CalculatePrice() + "kr.");
            }
            Console.WriteLine("Pris ialt: " + CalculatePrice() + "kr.");
        }
    }
}

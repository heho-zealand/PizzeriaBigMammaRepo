using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class OrderItem
    {
        private static int nextId = 1;
        private int _id;
        public Pizza Pizza { get; set; }
        public List<ExtraTopping> Toppings { get; set; }

        public int Number { get; set; }

        public OrderItem() { _id = nextId++; }
        public OrderItem(Pizza pizza, List<ExtraTopping> toppings, int number)
        {
            _id = nextId++;
            Pizza = pizza;
            Toppings = toppings;
            Number = number;
        }

        public double CalculatePrice()
        {
            double price = Pizza.Price;
            if (Toppings != null)
                foreach (ExtraTopping topping in Toppings)
                {
                    price += topping.Price;
                }
            return price * Number;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class PizzaMenuCard
    {
        private Dictionary<int, Pizza> _pizzas = new Dictionary<int, Pizza>();
        private List<ExtraTopping> _toppings = new List<ExtraTopping>();

        public void AddPizza(int id, string name, double price, string toppings)
        {
            Pizza pizza = new Pizza(id, name, price, toppings);
            _pizzas.Add(pizza.Id, pizza);
        }

        public Pizza GetPizza(int id)
        {
            if (_pizzas.ContainsKey(id))
                return _pizzas[id];
            return null;
        }

        public bool UpdatePizza(int id, Pizza pizza)
        {
            if (_pizzas.ContainsKey(id))
            {
                _pizzas[id] = pizza;
                return true;
            }
            return false;
        }

        public List<Pizza> SearchPizza(string topping)
        {
            List<Pizza> pizzas = new List<Pizza>();
            foreach (Pizza pizza in _pizzas.Values)
            {
                if (pizza.Description.ToLower().Contains(topping.ToLower())) pizzas.Add(pizza);
            }
            return pizzas;
        }

        public void AddExtraTopping(string name, double price)
        {
            _toppings.Add(new ExtraTopping(name, price));
        }

        public ExtraTopping GetToppingByName(string topping)
        {
            foreach (ExtraTopping t in _toppings)
            {
                if (t.Name.ToLower().Contains(topping.ToLower()))
                    return t;
            }
            return null;
        }

        public void PrintMenuCard()
        {
            foreach (Pizza p in _pizzas.Values)
            {
                Console.WriteLine(p.Id + ". " + p.Name + " - " + p.Price + ",-");
                Console.WriteLine(p.Description);
                Console.WriteLine();
            }
        }
    }
}

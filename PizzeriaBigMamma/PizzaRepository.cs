using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class PizzaRepository
    {
        private Dictionary<int, Pizza> _pizzas = new Dictionary<int, Pizza>();
        private List<ExtraTopping> _toppings = new List<ExtraTopping>();


        public PizzaRepository()
        {
            AddPizza(1, "Margherita", 65, "Tomat, ost");
            AddPizza(2, "Vesuvio", 70, "Tomat, ost, skinke");
            AddPizza(3, "Capricciosa", 75, "Tomat, ost, skinke, champignon, oliven");
            AddPizza(4, "Hawaii", 75, "Tomat, ost, skinke, ananas");
            AddPizza(5, "Pepperoni", 75, "Tomat, ost, pepperoni");
            AddPizza(6, "Quattro Stagioni", 80, "Tomat, ost, skinke, champignon, artiskok, oliven");
            AddPizza(7, "Quattro Formaggi", 80, "Tomat, ost, gorgonzola, mozzarella, parmesan, ricotta");
            AddPizza(8, "Vegetariana", 75, "Tomat, ost, champignon, artiskok, oliven, peberfrugt");
            AddPizza(9, "Calzone", 80, "Tomat, ost, skinke, champignon, peberfrugt, løg");
            AddPizza(10, "Bolognese", 75, "Tomat, ost, kødsauce, løg");
            AddPizza(11, "Carbonara", 75, "Tomat, ost, skinke, bacon, løg, æggeblomme");
            AddPizza(12, "Frutti di Mare", 80, "Tomat, ost, rejer, muslinger, blæksprutte, champignon, hvidløg");
            AddPizza(13, "Pescatore", 80, "Tomat, ost, rejer, muslinger, blæksprutte, champignon, hvidløg, oliven");
            AddPizza(14, "Pollo", 75, "Tomat, ost, kylling, champignon, peberfrugt, løg");
            AddPizza(15, "Tonno", 75, "Tomat, ost, tun, løg, oliven");
            AddPizza(16, "Mexicana", 75, "Tomat ost, oksekød, løg, jalapenos, peberfrugt, hvidløg");
            AddPizza(17, "Kebab", 75, "Tomat, ost, kebab, champignon, peberfrugt, løg");
            AddPizza(18, "Kylling", 75, "Tomat, ost, kylling, champignon, peberfrugt, løg");
            AddPizza(19, "Bacon", 75, "Tomat, ost, bacon, champignon, peberfrugt, løg");
            AddPizza(20, "Feta", 75, "Tomat, ost, feta, champignon, peberfrugt, løg");
            AddPizza(21, "Gorgonzola", 75, "Tomat, ost, gorgonzola, champignon, peberfrugt, løg");
            AddPizza(22, "Parma", 80, "Tomat, ost, parmaskinke, rucola, parmesan");
            AddPizza(23, "Rustica", 80, "Tomat, ost, oksekød, bacon, champignon, peberfrugt, løg");
            AddPizza(24, "Siciliana", 80, "Tomat, ost, oksekød, bacon, champignon, peberfrugt, løg, hvidløg");
            AddPizza(25, "Tosca", 80, "Tomat, ost, skinke, bacon, champignon, peberfrugt, løg");
            AddPizza(26, "Venezia", 80, "Tomat, ost, skinke, bacon, champignon, peberfrugt, løg, hvidløg");
            AddPizza(27, "Verona", 80, "Tomat, ost, skinke, bacon, champignon, peberfrugt, løg, hvidløg, oliven");
            AddPizza(28, "Bianca", 75, "Ost, gorgonzola, mozzarella, parmesan, ricotta, hvidløg");
            AddPizza(29, "Bella", 75, "Ost, gorgonzola, mozzarella, parmesan, ricotta, hvidløg, oliven");
            AddPizza(30, "Bella Italia", 80, "Tomat, ost, skinke, bacon, champignon, peberfrugt, løg, hvidløg, oliven");
            AddPizza(31, "Bella Napoli", 80, "Tomat, ost, skinke, bacon, champignon, peberfrugt, løg, hvidløg, oliven, artiskok");
        }

            public void AddPizza(int id, string name, double price, string toppings)
        {
            Pizza pizza = new Pizza(id, name, price, toppings);
            _pizzas.Add(pizza.Id, pizza);
        }

        
        public bool DeletePizza(int id)
        {
            if (_pizzas.ContainsKey(id))
            {
                _pizzas.Remove(id);
                return true;
            }
            return false;
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

        public List<Pizza> GetAllPizzas()
        {
            return _pizzas.Values.ToList();
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

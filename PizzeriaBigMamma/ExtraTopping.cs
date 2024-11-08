using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class ExtraTopping
    {
        private static int nextId = 1;
        private int _id;
        public string Name { get; set; }
        public double Price { get; set; }

        public ExtraTopping() { }
        public ExtraTopping(string name, double price)
        {
            _id = nextId++;
            Name = name;
            Price = price;
        }
    }
}

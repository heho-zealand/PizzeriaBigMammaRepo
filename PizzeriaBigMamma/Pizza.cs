namespace PizzeriaBigMamma
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Pizza() { }
        public Pizza(int id, string name, double price, string toppings)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = toppings;
        }

        public override string ToString()
        {
            //return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Description)}={Description}}}";
            return $"Pizza #{Id.ToString()} {Name}({Description}) af {Price.ToString()}Kr. ";
        }
    }
}

using PizzeriaBigMamma;

Store store = new Store();

void TestCustomerRepository()
{
    //*************  Test af CustomerRepository ****************************************************
    Console.WriteLine("Test af CustomerRepository");
    Console.WriteLine();


    Customer customer1 = new Customer(1, "Peter Sommer", "Musicon 34", "12345678");
    Customer customer2 = new Customer(2, "Andreas Odbjerg", "Musicon 88", "23232323");
    Customer customer3 = new Customer(3, "Peter AG", "Musicon 47", "22445678");

    store.CustomerRepository.AddCustomer(customer1);
    store.CustomerRepository.AddCustomer(customer2);
    store.CustomerRepository.AddCustomer(customer3);

    Console.WriteLine("Følgende 3 kunder er tilføjet listen i CustomerRepository: ");
    foreach (Customer customer in store.CustomerRepository.GetCustomers())
    {
        Console.WriteLine(customer);
    }
    Console.WriteLine();

    Console.WriteLine("Test af UpdateCustomer - Peter AG -> Peter AG Nielsen:");
    store.CustomerRepository.UpdateCustomer(3, new Customer(3, "Peter AG Nielsen", "Musicon 47", "22445678"));

    Console.WriteLine(store.CustomerRepository.GetCustomer(3));
    Console.WriteLine();


    Console.WriteLine("Test af DeleteCustomer - kunde 1 slettes og returneres:");
    Customer deletedCustomer = store.CustomerRepository.DeleteCustomer(1);
    Console.WriteLine(deletedCustomer);
    Console.WriteLine();


    Console.WriteLine("Test af GetCustomers() efter kunde 1 er slettet:");
    foreach (Customer customer in store.CustomerRepository.GetCustomers())
    {
        Console.WriteLine(customer);
    }

    Console.WriteLine();
}

void TestPizzaMenuCard()
{
    //*************  Test af PizzaMenuCard  ************************************
    Console.WriteLine("Test  af PizzaMenuCard");
    Console.WriteLine();

    store.PizzaMenuCard.AddPizza(1, "MARGHERITA", 69, "Tomato & cheese");
    store.PizzaMenuCard.AddPizza(2, "VESUVIO", 75, "Tomato,cheese & ham");
    store.PizzaMenuCard.AddPizza(3, "CAPRICCIOSA", 80, "Tomato,cheese,ham & mushrooms");
    store.PizzaMenuCard.AddPizza(4, "CALZONE", 80, "Baked pizza with tomato,cheese,ham & mushrooms");
    store.PizzaMenuCard.AddPizza(5, "QUATTRO STAGIONI", 85, "Tomato,cheese,ham,mushrooms,shrimp & peppers");

    Console.WriteLine("PrintMenuCard:");
    Console.WriteLine();
    store.PizzaMenuCard.PrintMenuCard();
    Console.WriteLine();

    Console.WriteLine("Test af SearchPizza('mushrooms')");
    List<Pizza> list = store.PizzaMenuCard.SearchPizza("mushrooms");

    foreach (Pizza pizza in list) Console.WriteLine(pizza);

    Console.WriteLine();


    store.PizzaMenuCard.AddExtraTopping("kebab", 10);
    store.PizzaMenuCard.AddExtraTopping("kylling", 10);
    store.PizzaMenuCard.AddExtraTopping("feta", 15);

}


void TestOrder()
{
    //*****************  Test af Order ***************************************
    Order order1 = new Order(store.CustomerRepository.GetCustomer(2), true);
    order1.AddOrderItem(new OrderItem(store.PizzaMenuCard.GetPizza(1), null, 2));
    order1.AddOrderItem(new OrderItem(store.PizzaMenuCard.GetPizza(2), new List<ExtraTopping>() { store.PizzaMenuCard.GetToppingByName("kebab") }, 1));
    order1.AddOrderItem(new OrderItem(store.PizzaMenuCard.GetPizza(3), null, 2));
    store.AddOrder(order1);

    Order order2 = new Order(null, false);
    order2.AddOrderItem(new OrderItem(store.PizzaMenuCard.GetPizza(2), new List<ExtraTopping>() { store.PizzaMenuCard.GetToppingByName("kylling"), store.PizzaMenuCard.GetToppingByName("feta") }, 2));
    order2.AddOrderItem(new OrderItem(store.PizzaMenuCard.GetPizza(3), null, 1));
    store.AddOrder(order2);

    foreach (Order order in store.GetAllOrders())
    {
        Console.WriteLine(order.PrintOrder());
        Console.WriteLine();
    }
}


TestCustomerRepository();
TestPizzaMenuCard();
TestOrder();

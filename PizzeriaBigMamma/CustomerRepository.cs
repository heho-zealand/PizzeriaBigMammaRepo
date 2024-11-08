using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaBigMamma
{
    public class CustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();

        public void AddCustomer(Customer customer) { _customers.Add(customer); }

        public Customer GetCustomer(int id)
        {
            foreach (var customer in _customers) { if (customer.Id == id) return customer; }
            return null;
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
            foreach (var c in _customers)
            {
                if (c.Id == id)
                {
                    c.Name = customer.Name;
                    c.Address = customer.Address;
                    c.Phone = customer.Phone;
                    return true;
                }
            }
            return false;
        }

        public Customer DeleteCustomer(int id)
        {
            foreach (var c in _customers)
            {
                if (c.Id == id) _customers.Remove(c);
                return c;
            }
            return null;
        }

        public List<Customer> GetCustomers() { return _customers; }
    }
}

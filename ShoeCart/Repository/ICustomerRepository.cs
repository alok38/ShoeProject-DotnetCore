using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);
        public Customer Add(Customer customer);
        public bool Update(Customer customer);
        public bool Remove(int id);
        

    }
}

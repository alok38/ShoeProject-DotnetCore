using ShoeCart.DataAccessLayer;
using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoeStoreContext _Shoecontext;
        public CustomerRepository(ShoeStoreContext context)
        {
            _Shoecontext = context;
        }
        public Customer Add(Customer customer)
        {
            _Shoecontext.Customers.Add(customer);
            _Shoecontext.SaveChanges();
            return customer;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _Shoecontext.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return _Shoecontext.Customers.FirstOrDefault(x => x.CustomerId == id);
        }
        public bool Remove(int id)

        {
            var CustomerToRemove = GetCustomer(id);
            _Shoecontext.Customers.Remove(CustomerToRemove);
            _Shoecontext.SaveChanges();
            return true;
        }
        public bool Update(Customer customer)
        {
            var CustomerToUpdate = GetCustomer(customer.CustomerId);
            CustomerToUpdate.CustomerName = customer.CustomerName;
            CustomerToUpdate.Address= customer.Address;
            CustomerToUpdate.PhoneNumber = customer.PhoneNumber;
            CustomerToUpdate.Age = customer.Age;
            CustomerToUpdate.EmailId = customer.EmailId;
            CustomerToUpdate.Password = customer.Password;
            _Shoecontext.SaveChanges();
            return true;
        }

    }
}

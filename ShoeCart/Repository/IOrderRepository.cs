using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public interface IOrderRepository
    {
        public Order Add(Order order);
        public Shoe GetShoesByOrderId(int id);
        public Order GetOrder(int id);
        public bool Remove(int id);
    }
}

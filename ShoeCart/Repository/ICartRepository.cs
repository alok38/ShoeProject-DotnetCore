using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public interface ICartRepository
    {
        public Cart Add(Cart cart);
        public List<Cart> GetCartsByCustomerId(int id);
        public Cart GetCart(int id);
        public bool Remove(int id);
    }
}

using ShoeCart.DataAccessLayer;
using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ShoeStoreContext _Shoecontext;
        public CartRepository(ShoeStoreContext context)
        {
            _Shoecontext = context;
        }

        public Cart Add(Cart cart)
        {
            _Shoecontext.Carts.Add(cart);
            _Shoecontext.SaveChanges();
            return cart;
        }
        public List<Cart> GetCartsByCustomerId(int id)
        {
            var carts = (from cart in _Shoecontext.Carts
                         where cart.CustomerId == id
                         select cart).ToList();
            return carts;
        }
        public Cart GetCart(int id)
        {
            return _Shoecontext.Carts.FirstOrDefault(x => x.CartId == id);
        }
        public bool Remove(int id)

        {
            var CartToRemove = GetCart(id);
            _Shoecontext.Carts.Remove(CartToRemove);
            _Shoecontext.SaveChanges();
            return true;
        }
    }

}

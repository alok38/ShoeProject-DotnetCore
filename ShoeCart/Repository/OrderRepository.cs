using ShoeCart.DataAccessLayer;
using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoeStoreContext _Shoecontext;
        public OrderRepository(ShoeStoreContext context)
        {
            _Shoecontext = context;
        }

        public Order Add(Order order)
        {
            _Shoecontext.Orders.Add(order);
            _Shoecontext.SaveChanges();
            return order;
        }
        public Shoe GetShoesByOrderId(int id)
        {
            var shoelist = (from order in _Shoecontext.Orders
                          join shoe in _Shoecontext.Shoes
                          on order.ShoeId equals shoe.ShoeId
                          where order.OrderId == id
                         select shoe).ToList();
            Shoe Shoes = new Shoe();
            Shoes = shoelist[0];
            return Shoes;
        }
        public Order GetOrder(int id)
        {
            return _Shoecontext.Orders.FirstOrDefault(x => x.OrderId == id);
        }
        public bool Remove(int id)

        {
            var OrderToRemove = GetOrder(id);
            _Shoecontext.Orders.Remove(OrderToRemove);
            _Shoecontext.SaveChanges();
            return true;
        }
    }
}

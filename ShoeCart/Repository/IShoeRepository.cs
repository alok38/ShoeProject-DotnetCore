using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public interface IShoeRepository
    {
        public IEnumerable<Shoe> GetAllShoes();
        public Shoe GetShoe(int id);
        public Shoe Add(Shoe shoe);
        public bool Update(Shoe shoe);
        public bool Remove(int id);
        public IEnumerable<Shoe> SortByName();
        public IEnumerable<Shoe> SortByNameDescending();
        public IEnumerable<Shoe> SortByPrice();
        public IEnumerable<Shoe> SortByPriceDescending();
        public IEnumerable<Shoe> SortByBrand();
        public IEnumerable<Shoe> SortByBrandDescending();
        public IEnumerable<Shoe> SortBySize();
        public IEnumerable<Shoe> SortBySizeDescending();



    }
}

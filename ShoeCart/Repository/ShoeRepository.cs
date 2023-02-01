using ShoeCart.DataAccessLayer;
using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ShoeStoreContext _Shoecontext;
        public ShoeRepository(ShoeStoreContext context)
        {
            _Shoecontext = context;
        }

        public Shoe Add(Shoe shoe)
        {
            _Shoecontext.Shoes.Add(shoe);
            _Shoecontext.SaveChanges();
            return shoe;
        }
        public IEnumerable<Shoe> GetAllShoes()
        {
            return _Shoecontext.Shoes.ToList();
        }
        public Shoe GetShoe(int id)
        {
            return _Shoecontext.Shoes.FirstOrDefault(x => x.ShoeId == id);
        }
        public bool Remove(int id)

        {
            var ShoeToRemove = GetShoe(id);
            _Shoecontext.Shoes.Remove(ShoeToRemove);
            _Shoecontext.SaveChanges();
            return true;
        }
        public bool Update(Shoe shoe)
        {
            var ShoeToUpdate = GetShoe(shoe.ShoeId);
            ShoeToUpdate.Price = shoe.Price;
            ShoeToUpdate.Size = shoe.Size;
            ShoeToUpdate.ShoeName = shoe.ShoeName;
            ShoeToUpdate.Brand = shoe.Brand;
            ShoeToUpdate.ShoeImage = shoe.ShoeImage;

            _Shoecontext.SaveChanges();
            return true;
        }
        public IEnumerable<Shoe> SortByName()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.ShoeName
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortByNameDescending()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.ShoeName descending
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortByPrice()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.Price
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortByPriceDescending()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.Price descending
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortByBrand()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.Brand
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortByBrandDescending()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.Brand descending
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortBySize()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.Size
                            select shoe).ToList();
            return ShoeList;
        }
        public IEnumerable<Shoe> SortBySizeDescending()
        {
            var ShoeList = (from shoe in _Shoecontext.Shoes
                            orderby shoe.Size descending
                            select shoe).ToList();
            return ShoeList;
        }
    }
}


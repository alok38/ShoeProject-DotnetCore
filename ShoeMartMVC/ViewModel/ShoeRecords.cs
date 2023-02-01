using ShoeMartMVC.Models;

namespace ShoeMartMVC.ViewModel
{
    public class ShoeRecords
    {
        public List<Shoe> shoes = new List<Shoe>();
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Total { get; set; }
    }
}

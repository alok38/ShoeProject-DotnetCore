namespace ShoeMartMVC.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReviewTime { get; set; }
        public int ShoeId { get; set; }


    }
}

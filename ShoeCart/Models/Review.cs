using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeCart.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int Rating { get; set; }

        public string Feedback { get; set; }
       public string CustomerName { get; set; }

        public DateTime ReviewTime { get; set; }

        [ForeignKey("ShoeId")]
        public int ShoeId { get; set; }



    }
}

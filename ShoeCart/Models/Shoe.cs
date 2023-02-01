using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeCart.Models
{
    public class Shoe
    {
        [Key]
        public int ShoeId { get; set; }

        public string ShoeImage { get; set; }

        [Required]
        public string ShoeName { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public string Brand { get; set; }
        
    }
}

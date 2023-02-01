using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeCart.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        
        public string EmailId { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

       
       

    }
}

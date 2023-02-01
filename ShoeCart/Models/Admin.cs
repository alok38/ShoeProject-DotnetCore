using System.ComponentModel.DataAnnotations;

namespace ShoeCart.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }

       
        public int AdminPhoneNumber { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace FashionWave.Models
{
    public class OrderInputModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}

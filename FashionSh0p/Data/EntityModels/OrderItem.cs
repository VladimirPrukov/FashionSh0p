using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWave.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }


        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}

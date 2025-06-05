using System.ComponentModel.DataAnnotations;

namespace FashionWave.Entities
{
    public class Order
    {
        public Order()
        {
            this.Items = new List<OrderItem>();
        }

        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public double Total { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}

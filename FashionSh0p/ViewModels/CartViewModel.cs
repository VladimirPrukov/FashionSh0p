namespace FashionWave.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public double Total => CartItems.Sum(i => i.Price * i.Quantity);
    }
}

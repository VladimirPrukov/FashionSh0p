using Microsoft.CodeAnalysis;
using System.Text.Json;

namespace FashionWave.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private const string SessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

        }

        public void AddToCart(CartItem cartItem)
        {
            var cart = GetCartItems();

            var existing = cart.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
            if (existing != null)
            {
                existing.Quantity += cartItem.Quantity;
            }
            else
            {
                cart.Add(cartItem);
            }
            SaveCart(cart);
        }

        public void ClearCart()
        {
            SaveCart(new List<CartItem>());
        }

        public List<CartItem> GetCartItems()
        {
            var session = httpContextAccessor.HttpContext?.Session;
            var json = session?.GetString(SessionKey);

            return json == null
                ? new List<CartItem>()
                :JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
        }

        public double GetTotal()
        {
            var cart = GetCartItems();
            return cart.Sum(i => i.Price * i.Quantity);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCartItems();
            var item = cart.First(x => x.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }

        }
        private void SaveCart(List<CartItem> cart)
        {
            var session = httpContextAccessor.HttpContext?.Session;
            var json = JsonSerializer.Serialize(cart);
            session?.SetString(SessionKey, json);
        }

        public void UpdateQuantity(int productId, int change)
        {
            var cart = httpContextAccessor.HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity += change;

                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
            }

            httpContextAccessor.HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
    }
}

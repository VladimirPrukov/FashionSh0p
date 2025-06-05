public interface ICartService
{
    void AddToCart(CartItem cartItem);

    void RemoveFromCart(int productId);

    List<CartItem> GetCartItems();

    double GetTotal();

    void ClearCart();

    void UpdateQuantity(int productId, int change);
}
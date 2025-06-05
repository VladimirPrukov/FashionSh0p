using FashionWave.Entities;
using FashionWave.Models;

public interface IOrderService
{
    int CreateOrder(OrderInputModel input, List<CartItem> items);

    Order GetOrderById(int orderId);
}


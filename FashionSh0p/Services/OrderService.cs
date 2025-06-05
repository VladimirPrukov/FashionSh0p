using FashionWave.Data;
using FashionWave.Models;
using FashionWave.Entities;
using Microsoft.EntityFrameworkCore;

namespace FashionWave.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext db;
        private readonly ICartService cartService;

        public OrderService(ApplicationDbContext db, ICartService cartService)
        {
            this.db = db;
            this.cartService = cartService;
        }

        public int CreateOrder(OrderInputModel input, List<CartItem> items)
        {
            var order = new Order
            {
                FullName = input.FullName,
                Address = input.Address,
                Phone = input.Phone,
                CreatedAt = DateTime.Now,
                Total = items.Sum(i => i.Price * i.Quantity),
                Items = items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.ImageUrl
                }).ToList()
            };

            db.Orders.Add(order);
            db.SaveChanges();

            return order.Id;
        }

        public Order GetOrderById(int orderId)
        {
            return db.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == orderId);
        }
    }
}
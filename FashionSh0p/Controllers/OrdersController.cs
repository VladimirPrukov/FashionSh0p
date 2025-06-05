using FashionWave.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionWave.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICartService cartService;
        private readonly IOrderService orderService;

        public OrdersController(ICartService cartService, IOrderService orderService)
        {
            this.cartService = cartService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var cartItems = cartService.GetCartItems();
            if (!cartItems.Any())
            {
                return RedirectToAction("Home", "Cart");
            }

            var viewModel = new OrderCreateViewModel
            {
                CartItems = cartItems,
                Total = cartItems.Sum(i => i.Price * i.Quantity)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model, string paymentType)
        {
            if (!ModelState.IsValid)
            {
                model.CartItems = cartService.GetCartItems();
                model.Total = model.CartItems.Sum(i => i.Price * i.Quantity);
                return View(model);
            }

            var cartItems = cartService.GetCartItems();

            var input = new OrderInputModel
            {
                FullName = model.FullName,
                Address = model.Address,
                Phone = model.Phone
            };

            if (paymentType == "cod")
            {
                orderService.CreateOrder(input, cartItems);
                cartService.ClearCart();
                return View("Confirmation");
            }

            if (paymentType == "card")
            {
                var orderId = orderService.CreateOrder(input, cartItems);
                cartService.ClearCart();
                return RedirectToAction("CreateCheckoutSession", "Payment", new { orderId });
            }

            return RedirectToAction("Home");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

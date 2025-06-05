using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace FashionWave.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderService orderService;

        public PaymentController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Success(int orderId)
        {
            var order = orderService.GetOrderById(orderId);
            if (order == null)
            {
                return RedirectToAction("Home");
            }

            return View(order);
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            return View("Cancel");
        }

        [HttpGet]
        public IActionResult CreateCheckoutSession(int orderId)
        {
            var order = orderService.GetOrderById(orderId);
            if (order == null)
            {
                return RedirectToAction("Home");
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = order.Items.Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "bgn",
                        UnitAmount = (long)(item.Price * 0.95 * 100), 
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Name
                        }
                    },
                    Quantity = item.Quantity
                }).ToList(),
                Mode = "payment",
                SuccessUrl = Url.Action("Success", "Payment", new { orderId }, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme)
            };

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }
    }
}
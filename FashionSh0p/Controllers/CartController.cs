using FashionWave.Models;
using FashionWave.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FashionWave.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            this.cartService = cartService;
            this.productService = productService;
        }

        public IActionResult Cart()
        {
            var items = cartService.GetCartItems();
            var model = new CartViewModel
            {
                CartItems = items
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart([FromBody] CartAddRequest request)
        {
            var product = productService.GetById(request.ProductId);
            if (product == null)
            {
                return Json(new { success = false, message = "Продуктът не беше намерен." });
            }

            var cartItem = new CartItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Quantity = request.Quantity
            };


            cartService.AddToCart(cartItem);

            return Json(new { success = true, message = "Добавено успешно!" });
        }


        public class CartAddRequest
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; } = 1;
        }
        public IActionResult Remove(int productId)
        {
            cartService.RemoveFromCart(productId);
            return RedirectToAction("Cart");
        }

        public IActionResult Clear()
        {
            cartService.ClearCart();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Count()
        {
            var items = cartService.GetCartItems();
            return Json(items.Sum(x => x.Quantity));
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int change)
        {
            cartService.UpdateQuantity(productId, change);
            return RedirectToAction("Cart");
        }
    }
}

public static class SessionExtensions
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}
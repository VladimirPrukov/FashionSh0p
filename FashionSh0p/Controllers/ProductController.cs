using FashionWave.Services;
using Microsoft.AspNetCore.Mvc;

namespace FashionWave.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Products(string? productType)
        {
            var products = productService.GetAllProducts(productType);
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = productService.GetById(id);
            if (product == null) return NotFound();

            return View(product);
        }
    }
}


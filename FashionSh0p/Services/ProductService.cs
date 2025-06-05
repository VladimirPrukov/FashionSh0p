using FashionWave.Data;
using FashionWave.Models;
using FashionWave.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FashionWave.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;

        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProductViewModel> GetAllProducts(string? productType)
        {
            var productsQuery = db.Products
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(productType))
            {
                productsQuery = productsQuery
                    .Where(p => p.ProductType.ToLower() == productType.ToLower());
            }

            return productsQuery
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                })
                .ToList();
        }

        public ProductDetailsViewModel GetById(int id)
        {
            return db.Products.Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                })
                .FirstOrDefault();
        }

    }
}

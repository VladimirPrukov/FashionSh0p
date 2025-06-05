using FashionWave.Models;
using FashionWave.ViewModels;

namespace FashionWave.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts(string? productType);

        ProductDetailsViewModel GetById(int id);
    }
}

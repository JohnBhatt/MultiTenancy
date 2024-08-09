using MultiTenancy.Data.DTOs;
using MultiTenancy.Models;

namespace MultiTenancy.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(CreateProductRequest request);
        bool DeleteProduct(int id);
    }
}

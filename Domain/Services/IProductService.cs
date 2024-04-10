using Domain.DTOs;

namespace Domain.Services;

public interface IProductService
{
    Task<ProductDto> AddProduct(ProductDto productDto);
    Task UpdateProduct(ProductDto productDto);
    Task DeleteProduct(int productId);
    Task<ProductDto> GetProduct(int productId);
    Task<IEnumerable<ProductDto>> GetProducts();
}
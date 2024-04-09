using Domain.DTOs;

namespace Domain.Services;

public interface IProductService
{
    Task<ProductDto> AddProduct(ProductDto permissionTypeDto);
    Task UpdateProduct(ProductDto permissionTypeDto);
    Task DeleteProduct(int permissionTypeId);
    Task<ProductDto> GetProduct(int permissionTypeId);
    Task<IEnumerable<ProductDto>> GetProducts();
}
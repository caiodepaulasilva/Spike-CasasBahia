using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productDto.Id);
            if (exists)
                throw new ConflictException("The product already exist.");

            var product = _mapper.Map<Product>(productDto);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productDto.Id);
            if (!exists)
                throw new ConflictException("The product type doesn't exist.");

            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productId);
            if (!exists)
                throw new NotFoundException("The product type doesn't exist.");

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            await _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProductDto> GetProduct(int productId)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productId);
            if (!exists)
                throw new NotFoundException("The product type doesn't exist.");

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }
    }
}

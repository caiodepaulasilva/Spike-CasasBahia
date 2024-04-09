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
            //if (exists)
            //    throw new ConflictException("The permission type already exist.");

            var product = _mapper.Map<Product>(productDto);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(ProductDto product)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == product.Id);
            if (!exists)
                throw new ConflictException("The permission type doesn't exist.");

            var permissionType = _mapper.Map<Product>(product);
            await _unitOfWork.ProductRepository.UpdateAsync(permissionType);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProduct(int permissionTypeId)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == permissionTypeId);
            if (!exists)
                throw new NotFoundException("The permission type doesn't exist.");

            var permissionType = await _unitOfWork.ProductRepository.GetByIdAsync(permissionTypeId);
            await _unitOfWork.ProductRepository.DeleteAsync(permissionType);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProductDto> GetProduct(int permissionTypeId)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == permissionTypeId);
            if (!exists)
                throw new NotFoundException("The permission type doesn't exist.");

            var permissionType = await _unitOfWork.ProductRepository.GetByIdAsync(permissionTypeId);
            var product = _mapper.Map<ProductDto>(permissionType);

            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var permissionsType = await _unitOfWork.ProductRepository.GetAllAsync();
            var permissionsTypeDto = _mapper.Map<IEnumerable<ProductDto>>(permissionsType);

            return permissionsTypeDto;
        }
    }
}

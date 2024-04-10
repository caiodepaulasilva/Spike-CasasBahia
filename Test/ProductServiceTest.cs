using Application.Services;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Moq;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public async Task Post_Successful()
        {
            // Arrange
            var productDto = new ProductDto()
            {
                Id = 1,
                Nome = "Produto_Teste",
                Pre�o = 25.8M,
                Quantidade = 3,
                DataCadastro = DateTime.Now,
                DataAltera��o = DateTime.Now.AddMonths(1)
            };

            var product = new Product
            {
                Id = productDto.Id,
                Nome = productDto.Nome,
                Pre�o = productDto.Pre�o,
                Quantidade = productDto.Quantidade,
                DataCadastro = productDto.DataCadastro,
                DataAltera��o = productDto.DataAltera��o
            };


            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<Product>(productDto)).Returns(product);
            mapperMock.Setup(mapper => mapper.Map<ProductDto>(product)).Returns(productDto);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(work => work.ProductRepository.ExistAsync(x => x.Id == It.IsAny<int>())).ReturnsAsync(It.IsAny<bool>());
            unitOfWorkMock.Setup(work => work.ProductRepository.AddAsync(It.IsAny<Product>()));
            unitOfWorkMock.Setup(work => work.SaveAsync());

            var productService = new ProductService(unitOfWorkMock.Object, mapperMock.Object);

            // Act            
            var result = await productService.AddProduct(productDto);

            // Assert
            Assert.Equal(result.Id, product.Id);
            Assert.Equal(result.Nome, product.Nome);
            Assert.Equal(result.Pre�o, product.Pre�o);
            Assert.Equal(result.Quantidade, product.Quantidade);
            Assert.Equal(result.DataCadastro, product.DataCadastro);
            Assert.Equal(result.DataAltera��o, product.DataAltera��o);

            mapperMock.Verify(mapper => mapper.Map<Product>(productDto), Times.Once());
            mapperMock.Verify(mapper => mapper.Map<ProductDto>(product), Times.Once());
            unitOfWorkMock.Verify(work => work.ProductRepository.AddAsync(It.IsAny<Product>()), Times.Once());
        }

        [Fact]
        public async Task GetAll_Successful()
        {
            // Arrange            
            var products = new List<Product>()
            {
                new ()
                {
                    Id = 1,
                    Nome = "Produto_Teste",
                    Pre�o = 25.8M,
                    Quantidade = 3,
                    DataCadastro = DateTime.Now,
                    DataAltera��o = DateTime.Now.AddMonths(1)
                }
            };

            var productDtos = new List<ProductDto>()
            {
                new ()
                {
                    Id = 1,
                    Nome = "Produto_Teste",
                    Pre�o = 25.8M,
                    Quantidade = 3,
                    DataCadastro = DateTime.Now,
                    DataAltera��o = DateTime.Now.AddMonths(1)
                }
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(work => work.ProductRepository.GetAllAsync(default, default)).ReturnsAsync(products);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProductDto>>(products)).Returns(productDtos);

            var productService = new ProductService(unitOfWorkMock.Object, mapperMock.Object);

            // Act            
            var result = await productService.GetProducts();

            // Assert
            Assert.NotNull(result);

            mapperMock.Verify(mapper => mapper.Map<IEnumerable<ProductDto>>(products), Times.Once());
            unitOfWorkMock.Verify(work => work.ProductRepository.GetAllAsync(default, default), Times.Once());
        }

        [Fact]
        public async Task GetById_Successful()
        {
            // Arrange
            var productId = 1;
            var product = new Product
            {
                Id = 1,
                Nome = "Produto_Teste",
                Pre�o = 25.8M,
                Quantidade = 3,
                DataCadastro = DateTime.Now,
                DataAltera��o = DateTime.Now.AddMonths(1)
            };

            var productDto = new ProductDto()
            {
                Id = 1,
                Nome = "Produto_Teste",
                Pre�o = 25.8M,
                Quantidade = 3,
                DataCadastro = DateTime.Now,
                DataAltera��o = DateTime.Now.AddMonths(1)
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(work => work.ProductRepository.ExistAsync(x => x.Id == productId)).ReturnsAsync(true);
            unitOfWorkMock.Setup(work => work.ProductRepository.GetByIdAsync(productId, default)).ReturnsAsync(product);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<ProductDto>(product)).Returns(productDto);

            var productService = new ProductService(unitOfWorkMock.Object, mapperMock.Object);

            // Act            
            var result = await productService.GetProduct(productId);

            // Assert
            Assert.Equal(result.Id, productDto.Id);
            Assert.Equal(result.Nome, productDto.Nome);
            Assert.Equal(result.Pre�o, productDto.Pre�o);
            Assert.Equal(result.Quantidade, productDto.Quantidade);
            Assert.Equal(result.DataCadastro, productDto.DataCadastro);
            Assert.Equal(result.DataAltera��o, productDto.DataAltera��o);

            mapperMock.Verify(mapper => mapper.Map<ProductDto>(It.IsAny<Product>()), Times.Once());
            unitOfWorkMock.Verify(work => work.ProductRepository.GetByIdAsync(productId, default), Times.Once());
        }
    }
}
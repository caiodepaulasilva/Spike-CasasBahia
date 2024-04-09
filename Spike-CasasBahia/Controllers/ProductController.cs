using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Spike_CasasBahia.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController(ILogger<ProductController> logger, IProductService productService) : ControllerBase
    {
        private readonly ILogger<ProductController> _logger = logger;
        private readonly IProductService _productService = productService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            var result = await _productService.AddProduct(product);
            _logger.LogInformation(result.ToString());
            return Ok(result);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromBody] int id)
        {
            var result = await _productService.GetProduct(id);
            _logger.LogInformation(result.ToString());
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromBody] ProductDto product)
        {
            var result = await _productService.GetProducts();
            _logger.LogInformation(result.ToString());
            return Ok(result);
        }
    }
}

using Application.Services;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spike_CasasBahia.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    public class ProductController(IProductService productService, IKafkaService kafkaService) : ControllerBase
    {        
        private readonly IProductService _productService = productService;
        private readonly IKafkaService _kafkaService = kafkaService;

        [HttpPost]        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            var product = await _productService.AddProduct(productDto);            
            await _kafkaService.ProduceAsync("Estoque", product);

            return Created(nameof(Get), product);
        }

        [HttpGet("id")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _productService.GetProduct(id);            
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetProducts();            
            return Ok(result);
        }
    }
}

using C001_SQLContext.Entities;
using C001_SQLContext.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _productRepository.GetAllProductsAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductEntity productEntity)
        {
            productEntity.Id = Guid.NewGuid();
            await _productRepository.AddProductAsync(productEntity);
            return Ok();
        }
    }
}

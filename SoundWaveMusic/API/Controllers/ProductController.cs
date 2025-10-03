using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var prodcuts = await _productService.GetAllProductsAsync();
            return Ok(prodcuts);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/product/album/{albumId}
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByAlbumId(int id)
        {
            var products = await _productService.GetProductsByAlbumIdAsync(id);
            return Ok(products);
        }

        // GET: api/product/vinyls
        [HttpGet("vinyls")]
        public async Task<ActionResult<IEnumerable<Vinyl>>> GetAllVinyls()
        {
            var vinyls = await _productService.GetAllVinylsAsync();
            return Ok(vinyls);
        }

        // GET: api/product/cds
        [HttpGet("CDs")]
        public async Task<ActionResult<IEnumerable<CD>>> GetAllCDs()
        {
            var cds = await _productService.GetAllCDsAsync();
            return Ok(cds);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Product ID does not match.");
            }

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        // DELETE: api/prodcut/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SoundWaveMusic.Entities;
using BusinessLayer.Interfaces;
using SoundWaveMusic.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(_mapper.Map<List<ProductModel>>(products));
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<ProductModel>(product));
        }

        // GET: api/product/album/{albumId}
        [HttpGet("album/{albumId}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByAlbumId(int albumId)
        {
            var products = await _productService.GetProductsByAlbumIdAsync(albumId);
            return Ok(_mapper.Map<List<ProductModel>>(products));
        }

        // GET: api/product/vinyls
        [HttpGet("vinyls")]
        public async Task<ActionResult<IEnumerable<VinylModel>>> GetAllVinyls()
        {
            var vinyls = await _productService.GetAllVinylsAsync();
            return Ok(_mapper.Map<List<VinylModel>>(vinyls));
        }

        // GET: api/product/cds
        [HttpGet("CDs")]
        public async Task<ActionResult<IEnumerable<CDModel>>> GetAllCDs()
        {
            var cds = await _productService.GetAllCDsAsync();
            return Ok(_mapper.Map<List<CDModel>>(cds));
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<ProductModel>> AddProduct([FromBody] ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            await _productService.AddProductAsync(product);

            var createdModel = _mapper.Map<ProductModel>(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdModel.ProductId }, createdModel);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModel productModel)
        {
            if (id != productModel.ProductId)
                return BadRequest("Product ID does not match.");

            var product = _mapper.Map<Product>(productModel);
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}

using E_CommerceBackend.Dtos.ProductDtos;
using E_CommerceBackend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace E_CommerceBackend.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if(createProductDto == null)
            {
                return BadRequest();
            }
            var newProduct = await _productService.CreateProductAsync(createProductDto);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.ProductId)
            {
                return BadRequest("Id mismatch between route and body.");
            }
            if(await _productService.GetProductByIdAsync(id) == null)
            {
                return BadRequest($"Product does not exist");
            }

            await _productService.UpdateProductAsync(updateProductDto);
            
            return Ok(updateProductDto);
        }

        [HttpDelete("{id:int}")]
        public async Task <IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }


        [HttpPost("{id:int}/image")]
        [Consumes("multipart/form-data")]   // Tell Swagger this endpoint expects form data
        public async Task<IActionResult> UploadProductImage(int id, [FromForm] ProductImageUploadDto productImageUploadDto)
        {
            if (productImageUploadDto.File == null || productImageUploadDto.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var success = await _productService.UpdateProductImageAsnc(id, productImageUploadDto);

            if (success)
            {
                return Ok("Image uploaded successfully.");
            }

            return StatusCode(500, "An error occured while uploading the image.");
        }
    }
}

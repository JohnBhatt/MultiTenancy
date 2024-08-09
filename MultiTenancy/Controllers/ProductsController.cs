using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Data.DTOs;
using MultiTenancy.Services;

namespace MultiTenancy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _productService.GetAllProducts();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post(CreateProductRequest request)
        {
            var result = _productService.CreateProduct(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}

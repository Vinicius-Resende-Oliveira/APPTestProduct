using APITestProduct.Models;
using APITestProduct.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestProduct.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly IBaseServices<Product> _productServices;

        public ProductController(IBaseServices<Product> productServices)
        {   
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(int Id)
        {
            var product = await _productServices.GetAll();

            return Ok(product);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            var product = await _productServices.Get(Id);
            if (product == null)
                return NotFound(new Product());

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            Product _product = new Product() 
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
            };

            await _productServices.Add(_product);
            return Ok(_product);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Product>> Put(int Id, [FromBody] Product product)
        {
            Product _product = await _productServices.Get(Id);
            if (_product == null)
                return NotFound(_product);

            _product = product;

            await _productServices.Update(_product);
            return Ok(_product);
        }
        [HttpDelete("{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int Id)
        {
            var product = await _productServices.Get(Id);
            if (product == null)
                return NotFound();
            await _productServices.Delete(Id);
            return Ok();
        }
    }
}

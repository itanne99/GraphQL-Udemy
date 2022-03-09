using System.Collections.Generic;
using GraphQL_Udemy.Interfaces;
using GraphQL_Udemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Udemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private IProduct _productService;

        public ProductsController(IProduct productService)
        {
            this._productService = productService;
        }
        
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }
        
        // GET: api/<ProductsController>/#
        [HttpGet("{id:int}")]
        public Product Get(int id)
        {
            return _productService.GetProductById(id);
        }
        
        // POST api/<ProductsController>
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return product;
        }
        
        // PUT api/<ProductsController>/#
        [HttpPut("{id:int}")]
        public Product Put(int id, [FromBody] Product product)
        {
            _productService.UpdateProduct(id, product);
            return product;
        }
        
        // DELETE api/<ProductsController>/#
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
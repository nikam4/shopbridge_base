using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            try
            {
                return Ok(await productService.GetProducts<Product>());
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message, exception);
                return null;
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (id > 0)
            {
                try
                {
                    return Ok(await productService.GetProducts<Product>(id));
                }
                catch (Exception exception)
                {
                    logger.LogError(exception.Message, exception);
                    return null;
                }
            }
            return BadRequest("Invalid id");

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id > 0 && product != null)
            {
                try
                {
                    return Ok(await productService.PutProduct(id, product));
                }
                catch (Exception exception)
                {
                    logger.LogError(exception.Message, exception);
                    return null;
                }
            }
            return BadRequest("Invalid id/product details");
        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product != null)
            {
                try
                {
                    return Ok(await productService.PostProduct(product));
                }
                catch (Exception exception)
                {
                    logger.LogError(exception.Message, exception);
                    return null;
                }
            }
            return BadRequest("Invalid product details");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id > 0)
            {
                try
                {
                    return Ok(await productService.DeleteProduct(id));
                }
                catch (Exception exception)
                {
                    logger.LogError(exception.Message, exception);
                    return null;
                }
            }
            return BadRequest("Invalid id");
        }

        private bool ProductExists(int id)
        {
            return productService.ProductExists(id);
        }
    }
}

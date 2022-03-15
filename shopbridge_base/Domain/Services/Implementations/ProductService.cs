using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetProducts<T>() where T : class
        {
            return await _repository.GetProducts<T>();
        }

        public async Task<Product> GetProducts<T>(int id) where T : class
        {
            return await _repository.GetProducts<T>(id);
        }

        public async Task<bool> PutProduct(int id, Product product)
        {
            return await _repository.PutProduct(id, product);
        }

        public async Task<Product> PostProduct(Product product)
        {
            return await _repository.PostProduct(product);
        }

        public bool ProductExists(int id)
        {
            return _repository.ProductExists(id);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _repository.DeleteProduct(id);
        }
    }
}

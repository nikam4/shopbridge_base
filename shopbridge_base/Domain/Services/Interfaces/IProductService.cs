using Shopbridge_base.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts<T>() where T : class;
        Task<Product> GetProducts<T>(int id) where T : class;
        Task<bool> PutProduct(int id, Product product);
        Task<Product> PostProduct(Product product);
        bool ProductExists(int id);
        Task<bool> DeleteProduct(int id);
    }
}

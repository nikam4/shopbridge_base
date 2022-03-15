using Shopbridge_base.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Product>> GetProducts<T>() where T : class;
        Task<Product> GetProducts<T>(int id) where T : class;
        Task<bool> PutProduct(int id, Product product);
        Task<Product> PostProduct(Product product);
        bool ProductExists(int id);
        /// <summary>
        /// Soft delete the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True/False value after deletion of record</returns>
        Task<bool> DeleteProduct(int id);
    }
}

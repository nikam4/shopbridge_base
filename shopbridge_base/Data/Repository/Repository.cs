using Shopbridge_base.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly Shopbridge_Context dbcontext;

        public Repository(Shopbridge_Context _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }

        /// <summary>
        /// Soft delete the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True/False value after deletion of record</returns>
        public async Task<bool> DeleteProduct(int id)
        {
            var data = dbcontext.Product.Where(x => x.Product_Id == id).FirstOrDefault();
            if (data != null && data.Product_Id > 0)
            {
                data.IsDeleted = true;
                dbcontext.Update(data);
                var rows = dbcontext.SaveChanges();
                if (rows > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetProducts<T>() where T : class
        {
            return (from p in dbcontext.Product
                    where p.IsDeleted == false
                    select p).ToList();
        }

        public async Task<Product> GetProducts<T>(int id) where T : class
        {
            return dbcontext.Product.Where(x => x.Product_Id == id && x.IsDeleted == false).FirstOrDefault();
        }

        public async Task<Product> PostProduct(Product product)
        {
            var data = await dbcontext.Product.AddAsync(product);
            var row = dbcontext.SaveChanges();
            if (row > 0)
            {
                return data.Entity;
            }
            return null;

        }

        public bool ProductExists(int id)
        {
            return (from p in dbcontext.Product
                    where p.Product_Id == id && p.IsDeleted == false
                    select p).Any();
        }

        public async Task<bool> PutProduct(int id, Product product)
        {
            var data = dbcontext.Product.Where(x => x.Product_Id == id).FirstOrDefault();
            if (data != null && data.Product_Id > 0)
            {
                data.ProductName = product.ProductName;
                data.Price = product.Price;
                data.IsDeleted = product.IsDeleted;
            }
            dbcontext.Update(data);
            var rows = dbcontext.SaveChanges();
            if (rows > 0)
            {
                return true;
            }
            return false;
        }
    }
}

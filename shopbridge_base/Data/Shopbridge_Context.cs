using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;

namespace Shopbridge_base.Data
{
    public class Shopbridge_Context : DbContext
    {
        private string connectionString;

        public Shopbridge_Context(DbContextOptions<Shopbridge_Context> options)
            : base(options)
        {
        }

        public Shopbridge_Context(DbContextOptions<Shopbridge_Context> options, string connectionString) : this(options)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Product> Product { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Shopbridge_base.Domain.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}

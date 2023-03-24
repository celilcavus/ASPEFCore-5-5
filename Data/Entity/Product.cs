using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    // [Table("Product", Schema = "c")]
    public class Product
    {
        // [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // [MaxLength(40)]
        public string? name { get; set; }
        // [MaxLength(40)]
        public decimal price { get; set; }
        public List<SaleHistory>? SaleHistories { get; set; }
        public ProductDetail? ProductDetails { get; set; }
        public DateTime CreatingDate { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }

        
    }
}
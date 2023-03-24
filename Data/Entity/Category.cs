using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    // [Table("Categories")]
    public class Category
    {
        // [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // [MaxLength(40)]
        public string? Name { get; set; }

         public List<ProductCategory>? ProductCategories { get; set; }
    }
}
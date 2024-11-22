using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWSales.Data.Entities.DwVentas
{
    [Table("DimCategory")]
    public class DimCategory
    {
        [Key]
        public int CategoryKey { get; set; } 
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty; 
        public string? Description { get; set; } 
    }
}

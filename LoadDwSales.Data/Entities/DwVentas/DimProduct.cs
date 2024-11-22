using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDwSales.Data.Entities.DwVentas
{
    [Table("DimProduct")]
    public class DimProduct
    {
        [Key]
        public int ProductKey { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}

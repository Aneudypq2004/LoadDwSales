
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWSales.Data.Entities.DwVentas
{

    [Table("DimShippers")]
    public class DimShipper
    {
        [Key]
        public int ShipperKey { get; set; }
        [Required]
        public int ShipperID { get; set; }
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}

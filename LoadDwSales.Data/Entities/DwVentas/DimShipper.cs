
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWSales.Data.Entities.DwVentas
{

    [Table("DimShipeers")]
    public class DimShipper
    {


        [Key]
        public int ShipperKey { get; set; }
        public int ShipperId { get; set; }
        public string? ShipperName { get; set; }
    }
}

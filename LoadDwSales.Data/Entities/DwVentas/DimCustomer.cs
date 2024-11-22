

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWSales.Data.Entities.DwVentas
{
    [Table("DimCustomers")]
    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }
        [Required]
        public string CustomerID { get; set; } = string.Empty;
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        public string? ContactName { get; set; }
        public string? Country { get; set; }
    }
}

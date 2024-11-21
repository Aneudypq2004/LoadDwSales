

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWSales.Data.Entities.DwVentas
{
    [Table("DimCustomers")]
    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}

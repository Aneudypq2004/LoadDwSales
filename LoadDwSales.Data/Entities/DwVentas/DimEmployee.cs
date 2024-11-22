

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWSales.Data.Entities.DwVentas
{
    [Table("DimEmployee")]
    public class DimEmployee
    {
        [Key]
        public int EmployeeKey { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty; 
        [Required]
        public string LastName { get; set; } = string.Empty; 
        public string? Title { get; set; } 
        public DateTime? HireDate { get; set; }
    }
}

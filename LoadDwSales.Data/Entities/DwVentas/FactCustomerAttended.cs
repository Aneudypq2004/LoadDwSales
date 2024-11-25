using System.ComponentModel.DataAnnotations;

namespace LoadDwSales.Data.Entities.DwVentas
{
    public class FactCustomerAttended
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int TotalCustomersServed { get; set; }
    }
}

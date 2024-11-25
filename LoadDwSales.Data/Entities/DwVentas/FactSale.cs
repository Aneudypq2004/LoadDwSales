using System.ComponentModel.DataAnnotations;

namespace LoadDwSales.Data.Entities.DwVentas
{
    public class FactSale
    {
        [Key]
        public int Id { get; set; } 
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int ShipperId { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? DateKey { get; set; }
        public int? Año { get; set; }
        public int? Mes { get; set; }
        public decimal? TotalSales { get; set; }
    }
}

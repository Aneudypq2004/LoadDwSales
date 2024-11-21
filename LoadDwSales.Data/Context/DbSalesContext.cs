

using LoadDWSales.Data.Entities.DwVentas;
using Microsoft.EntityFrameworkCore;

namespace LoadDWSales.Data.Context
{
    public class DbSalesContext(DbContextOptions<DbSalesContext> options) : DbContext(options)
    {
        public DbSet<DimEmployee> DimEmployees { get; set; }
        public DbSet<DimProductCategory> DimProductCategories { get; set; }
        public DbSet<DimCustomer> DimCustomers { get; set; }
        public DbSet<DimShipper> DimShippers { get; set; }
    }
}

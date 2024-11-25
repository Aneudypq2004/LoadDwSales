


using LoadDWSales.Data.Entities.Northwind;
using LoadDWSales.Data.Entities.Norwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDWSales.Data.Context
{
    public partial class NortwindContext(DbContextOptions<NortwindContext> options) : DbContext(options)
    {

        #region"Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<VwSales> VwSales { get; set; }
        public DbSet<VwCustomersAttended> VwCustomersAttended { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VwCustomersAttended>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VwCustomersAttended", "dbo");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
            });

            modelBuilder.Entity<VwSales>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VwSales", "dbo");

                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength()
                    .HasColumnName("CustomerID");
                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            });
        }
    }
}

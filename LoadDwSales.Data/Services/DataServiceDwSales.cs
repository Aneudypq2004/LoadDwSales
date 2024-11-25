

using LoadDWSales.Data.Context;
using LoadDWSales.Data.Entities.DwVentas;
using LoadDWSales.Data.Interfaces;
using LoadDWSales.Data.Core;
using Microsoft.EntityFrameworkCore;
using LoadDwSales.Data.Entities.DwVentas;

namespace LoadDWSales.Data.Services
{
    public class DataServiceDwSales(NortwindContext norwindContext,
                               DbSalesContext salesContext) : IDataServiceDwSales
    {
        private readonly NortwindContext _northwindContext = norwindContext;
        private readonly DbSalesContext _salesContext = salesContext;
        public async Task<BaseResult> LoadDHW()
        {
            BaseResult result = new() { Success = true };
            try
            {
                //await LoadDimEmployee();
                //await LoadDimCustomers();
                //await LoadDimShippers();
                //await LoadDimCategory();
                //await LoadDimProduct();


                await LoadFactCustomersAttended();
                await LoadFactSales();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando el DWH Ventas. {ex.Message}";
            }

            return result;
        }

        private async Task<BaseResult> LoadDimCustomers()
        {
            BaseResult result = new() { Success = true };
            try
            {
                await _salesContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE DimCustomers");
                var customers = await _northwindContext.Customers.AsNoTracking()
                    .Select(cust => new DimCustomer
                    {
                        CustomerID = cust.CustomerId ?? string.Empty,
                        CompanyName = cust.CompanyName ?? string.Empty,
                        ContactName = cust.ContactName,
                        Country = cust.Country
                    }).ToListAsync();

                await _salesContext.DimCustomers.AddRangeAsync(customers);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de clientes: {ex.Message}";
            }

            return result;
        }

        private async Task<BaseResult> LoadDimEmployee()
        {
            BaseResult result = new() { Success = true };

            try
            {
                await _salesContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE DimEmployee");

                var employees = await _northwindContext.Employees.AsNoTracking()
                    .Select(emp => new DimEmployee
                    {
                        EmployeeID = emp.EmployeeId,
                        FirstName = emp.FirstName ?? string.Empty,
                        LastName = emp.LastName ?? string.Empty,
                        Title = emp.Title,
                        HireDate = emp.HireDate
                    }).ToListAsync();

                await _salesContext.DimEmployees.AddRangeAsync(employees);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de empleados: {ex.Message}";
            }

            return result;
        }
        private async Task<BaseResult> LoadDimShippers()
        {
            BaseResult result = new() { Success = true };

            try
            {
                await _salesContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE DimShippers");

                var shippers = await _northwindContext.Shippers.AsNoTracking()
                    .Select(ship => new DimShipper
                    {
                        ShipperID = ship.ShipperID,
                        CompanyName = ship.CompanyName ?? string.Empty,
                        Phone = ship.Phone
                    }).ToListAsync();

                await _salesContext.DimShippers.AddRangeAsync(shippers);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de shippers: {ex.Message}";
            }

            return result;
        }
        private async Task<BaseResult> LoadDimCategory()
        {
            BaseResult result = new() { Success = true };

            try
            {
                await _salesContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE DimCategory");

                var categories = await _northwindContext.Categories.AsNoTracking()
                    .Select(cat => new DimCategory
                    {
                        CategoryID = cat.CategoryId,
                        CategoryName = cat.CategoryName ?? string.Empty,
                        Description = cat.Description
                    }).ToListAsync();

                _salesContext.DimCategories.AddRange(categories);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de categorías: {ex.Message}";
            }

            return result;
        }
        private async Task<BaseResult> LoadDimProduct()
        {
            BaseResult result = new() { Success = true };

            try
            {
                await _salesContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE DimProduct");

                var products = await _northwindContext.Products.AsNoTracking()
                    .Select(prod => new DimProduct
                    {
                        ProductID = prod.ProductId,
                        ProductName = prod.ProductName ?? string.Empty,
                        CategoryID = prod.CategoryId,
                        SupplierID = prod.SupplierId,
                        UnitPrice = prod.UnitPrice,
                        UnitsInStock = prod.UnitsInStock,
                        Discontinued = prod.Discontinued
                    }).ToListAsync();

                await _salesContext.DimProducts.AddRangeAsync(products);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de productos: {ex.Message}";
            }

            return result;
        }
        private async Task<BaseResult> LoadFactSales()
        {
            BaseResult result = new();
            try
            {
                var sales = await _northwindContext.VwSales.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el fact de ventas {ex.Message} ";
            }

            return result;
        }
        private async Task<BaseResult> LoadFactCustomersAttended()
        {
            BaseResult result = new() { Success = true };

            try
            {
                var customerAttended = await _northwindContext.VwServedCustomers.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el fact de clientes atendidos {ex.Message} ";
            }
            return result;
        }

    }
}

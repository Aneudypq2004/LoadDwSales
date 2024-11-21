

using LoadDWSales.Data.Context;
using LoadDWSales.Data.Entities.DwVentas;
using LoadDWSales.Data.Interfaces;
using LoadDWSales.Data.Result;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LoadDWSales.Data.Services
{
    public class DataServiceDwVentas(NortwindContext norwindContext,
                               DbSalesContext salesContext) : IDataServiceDwVentas
    {
        private readonly NortwindContext _norwindContext = norwindContext;
        private readonly DbSalesContext _salesContext = salesContext;

        public async Task<BaseResult> LoadDHW()
        {
            BaseResult result = new BaseResult();
            try
            {
                await LoadDimEmployee();
                await LoadDimProductCategory();
                await LoadDimCustomers();
                await LoadDimShippers();
                await LoadFactSales();
                await LoadFactCustomerServed();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el DWH Ventas. {ex.Message}";
            }

            return result;
        }

        private async Task<BaseResult> LoadDimEmployee()
        {
            BaseResult result = new BaseResult();

            try
            {
                var employees = await _norwindContext.Employees.AsNoTracking().Select(emp => new DimEmployee()
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeName = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToListAsync();

                await _salesContext.DimEmployees.AddRangeAsync(employees);
                await _salesContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando la dimension de empleado {ex.Message}";
            }

            return result;
        }

        private async Task<BaseResult> LoadDimProductCategory()
        {
            BaseResult result = new BaseResult();
            try
            {
     

                var productCategories = await (from product in _norwindContext.Products
                                               join category in _norwindContext.Categories on product.CategoryId equals category.CategoryId
                                               select new DimProductCategory()
                                               {
                                                   CategoryId = category.CategoryId,
                                                   ProductName = product.ProductName,
                                                   CategoryName = category.CategoryName,
                                                   ProductId = product.ProductId
                                               }).AsNoTracking().ToListAsync();


                await _salesContext.DimProductCategories.AddRangeAsync(productCategories);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimension de producto y categoria. {ex.Message}";
            }
            return result;
        }

        private async Task<BaseResult> LoadDimCustomers()
        {
            BaseResult operaction = new BaseResult() { Success = false };
            try
            {
              
                var customers = await _norwindContext.Customers.Select(cust => new DimCustomer()
                {
                    CustomerId = cust.CustomerId,
                    CustomerName = cust.CompanyName

                }).AsNoTracking()
                  .ToListAsync();

                await _salesContext.DimCustomers.AddRangeAsync(customers);
                await _salesContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                operaction.Success = false;
                operaction.Message = $"Error: {ex.Message} cargando la dimension de clientes.";
            }
            return operaction;
        }

        private async Task<BaseResult> LoadDimShippers()
        {
            BaseResult result = new BaseResult();

            try
            {
                var shippers = await _norwindContext.Shippers.Select(ship => new DimShipper()
                {
                    ShipperId = ship.ShipperID,
                    ShipperName = ship.CompanyName
                }).ToListAsync();


                await _salesContext.DimShippers.AddRangeAsync(shippers);
                await _salesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando la dimension de shippers { ex.Message } ";
            }
            return result;
        }

        private async Task<BaseResult> LoadFactSales() 
        {
            BaseResult result = new BaseResult();

            try
            {
                var ventas = await _norwindContext.Vwventas.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el fact de ventas {ex.Message} ";
            }

            return result;
        }


        private async Task<BaseResult> LoadFactCustomerServed()
        {
            BaseResult result = new BaseResult() { Success = true };

            try
            {
                var customerServed = await _norwindContext.VwServedCustomers.AsNoTracking().ToListAsync();
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

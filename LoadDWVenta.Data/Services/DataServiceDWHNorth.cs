

using LoadDWVenta.Data.Context;
using LoadDWVenta.Data.Entities.DWHNorthwindOrders;
using LoadDWVenta.Data.Interfaces;
using LoadDWVenta.Data.Result;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LoadDWVenta.Data.Services
{
    public class DataServiceDWHNorth : IDataServiceDWHNorth
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DWHContext _dWHContext;

        public DataServiceDWHNorth(NorthwindContext northwindContext,
                                   DWHContext dWHContext)
        {
            _northwindContext = northwindContext;
            _dWHContext = dWHContext;
        }
            
        public async Task<OperactionResult> LoadDHW()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                await LoadDimEmployee();
                await LoadDimProductAndCategory();
                // await LoadDimCustomers();
                // await LoadDimShippers();
                // await LoadFactSales();
                // await LoadFactCustomerServed();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el DWH. {ex.Message}";
            }

            return result;
        }

        private async Task<OperactionResult> LoadDimEmployee()
        {
            OperactionResult result = new OperactionResult();

            try
            {
                var employees = await _northwindContext.Employees.AsNoTracking().Select(emp => new DimEmployee()
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeName = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToListAsync();

                await _dWHContext.DimEmployee.AddRangeAsync(employees);

                await _dWHContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando la dimension de empleado {ex.Message}";
            }


            return result;
        }

        private async Task<OperactionResult> LoadDimProductAndCategory()
        {
            OperactionResult result = new OperactionResult();
            try
            {
              
                var categories = await (from category in _northwindContext.Categories
                                        select new DimCategory
                                        {
                                            CategoryID = category.CategoryId,
                                            CategoryName = category.CategoryName,
                                            Description = category.Description
                                        }).AsNoTracking().ToListAsync();

                await _dWHContext.DimCategory.AddRangeAsync(categories);

               
                var products = await (from product in _northwindContext.Products
                                      select new DimProduct
                                      {
                                          ProductId = product.ProductId,
                                          ProductName = product.ProductName,
                                          SupplierId = product.SupplierId,
                                          CategoryId = product.CategoryId,
                                          QuantityPerUnit = product.QuantityPerUnit,
                                          UnitPrice = product.UnitPrice,
                                          UnitsInStock = product.UnitsInStock,
                                          UnitsOnOrder = product.UnitsOnOrder,
                                          ReorderLevel = product.ReorderLevel,
                                          Discontinued = product.Discontinued
                                      }).AsNoTracking().ToListAsync();

                await _dWHContext.DimProduct.AddRangeAsync(products);

               
                await _dWHContext.SaveChangesAsync();

                result.Success = true;
                result.Message = "Data loaded successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading data. {ex.Message}";
            }
            return result;
        }


        /*private async Task<OperactionResult> LoadDimCustomers()
        {
            OperactionResult operaction = new OperactionResult() { Success = false };


            try
            {
               

                var customers = await _northwindContext.Customers.Select(cust => new DimCustomer()
                {
                    CustomerId = cust.CustomerId,
                    CustomerName = cust.CompanyName

                }).AsNoTracking()
                  .ToListAsync();

               

                await _dWHContext.DimCustomer.AddRangeAsync(customers);
                await _dWHContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                operaction.Success = false;
                operaction.Message = $"Error: {ex.Message} cargando la dimension de clientes.";
            }
            return operaction;
        }*/
        

        /*private async Task<OperactionResult> LoadDimShippers()
        {
            OperactionResult result = new OperactionResult();

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

        private async Task<OperactionResult> LoadFactSales() 
        {
            OperactionResult result = new OperactionResult();

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


        private async Task<OperactionResult> LoadFactCustomerServed()
        {
            OperactionResult result = new OperactionResult() { Success = true };

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
        }*/
    }
}

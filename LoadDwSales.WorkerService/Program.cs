using LoadDwSales.WorkerService;
using LoadDWSales.Data.Context;
using LoadDWSales.Data.Interfaces;
using LoadDWSales.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<NortwindContext>(options =>
                                                     options.UseSqlServer(builder.Configuration.GetConnectionString("DbNorthwind")));

builder.Services.AddDbContext<DbSalesContext>(options =>
                                          options.UseSqlServer(builder.Configuration.GetConnectionString("DbSales")));

builder.Services.AddScoped<IDataServiceDwSales, DataServiceDwSales>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

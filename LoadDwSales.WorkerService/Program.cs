using LoadDwSales.WorkerService;
using LoadDWSales.Data.Context;
using LoadDWSales.Data.Interfaces;
using LoadDWSales.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContextPool<NortwindContext>(options =>
                                                     options.UseSqlServer(builder.Configuration.GetConnectionString("DbNorwind")));

builder.Services.AddDbContextPool<DbSalesContext>(options =>
                                          options.UseSqlServer(builder.Configuration.GetConnectionString("DbSales")));

builder.Services.AddScoped<IDataServiceDwVentas, DataServiceDwVentas>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

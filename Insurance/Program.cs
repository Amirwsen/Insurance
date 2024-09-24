using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Database;
using infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);
var mvcBuilder = builder.Services.AddControllers();

mvcBuilder.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

var services = builder.Services;
services.AddScoped<IInsuranceRepository, InsuranceRepository>();
services.AddScoped<IInsuranceOrderRepository, InsuranceOrderRepository>();
services.AddScoped<AddInsuranceUseCase, AddInsuranceUseCase>();
services.AddScoped<AddInsuranceOrderUseCase, AddInsuranceOrderUseCase>();
services.AddScoped<GetOrdersUseCase, GetOrdersUseCase>();

var app = builder.Build();


await using var scope = app.Services.CreateAsyncScope();
await using (var db = scope.ServiceProvider.GetService<DatabaseContext>())
    await db!.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
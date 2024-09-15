using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Database;
using infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var services = builder.Services;
services.AddScoped<IInsuranceRepository, InsuranceRepository>();
services.AddScoped<IInsuranceOrderRepository, InsuranceOrderRepository>();
services.AddScoped<AddInsuranceUseCase, AddInsuranceUseCase>();
services.AddScoped<AddInsuranceOrderUseCase, AddInsuranceOrderUseCase>();

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
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<InsuranceOrder> InsuranceOrders { get; set; }
    public DbSet<Insurance> Insurances { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<InsuranceOrder>().HasKey(order => order.Id);
        builder.Entity<Insurance>().HasKey(insurance => insurance.Id);

        builder.Entity<Insurance>()
            .HasMany(x => x.InsuranceOrders)
            .WithOne(order => order.Insurance)
            .HasForeignKey(x => x.InsuranceId)
            .IsRequired();

        base.OnModelCreating(builder);
    }
}
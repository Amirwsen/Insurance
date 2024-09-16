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
            .WithOne()
            .HasForeignKey(x => x.InsuranceId)
            .IsRequired();

        // builder.Entity<InsuranceOrder>()
        //     .HasCheckConstraint("CheckSurgery", "Surgery >= 5000 AND Surgery <= 500000000");
        // builder.Entity<InsuranceOrder>()
        //     .HasCheckConstraint("CheckDentistry", "Dentistry >= 4000 AND Dentistry <= 400000000");
        // builder.Entity<InsuranceOrder>()
        //     .HasCheckConstraint("CheckHospitalized", "Hospitalized >= 2000 AND Hospitalized <= 200000000");

        base.OnModelCreating(builder);
    }
}
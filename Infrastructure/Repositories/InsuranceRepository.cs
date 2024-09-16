using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Database;

namespace infrastructure.Repositories;

public class InsuranceRepository : IInsuranceRepository
{
    private readonly DatabaseContext _database;

    public InsuranceRepository(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<Insurance> Add(InsuranceRequest request, CancellationToken cancellationToken)
    {
        var result = new Insurance
        {
            Title = request.Title,
        };
       await _database.Insurances.AddAsync(result, cancellationToken);
       await _database.SaveChangesAsync(cancellationToken);
       return result;
    }
}
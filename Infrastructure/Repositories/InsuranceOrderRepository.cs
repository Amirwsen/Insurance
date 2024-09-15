using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Database;

namespace infrastructure.Repositories;

public class InsuranceOrderRepository : IInsuranceOrderRepository
{
    private readonly DatabaseContext _database;

    public InsuranceOrderRepository(DatabaseContext database)
    {
        _database = database;
    }
    public async Task<InsuranceOrder> Add(InsuranceOrderRequest request, CancellationToken cancellationToken)
    {
        var result = new InsuranceOrder
        {
            Investment = request.Investment,
            Type = request.Type
        };
        await _database.InsuranceOrders.AddAsync(result, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);
        return result;
    }
}
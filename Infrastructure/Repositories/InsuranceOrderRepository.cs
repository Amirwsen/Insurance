using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            Type = request.Type,
            InsuranceId = request.InsuranceId
        };
        await _database.InsuranceOrders.AddAsync(result, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<InsuranceOrder>> GetOrders(CancellationToken cancellationToken)
    {
        var result = _database.InsuranceOrders.Include(order => order.Insurance);
        return await result.ToListAsync(cancellationToken);
    }
}
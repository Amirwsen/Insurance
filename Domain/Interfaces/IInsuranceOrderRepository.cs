using Domain.Entities;
using infrastructure.Repositories;

namespace Domain.Interfaces;

public interface IInsuranceOrderRepository 
{
    Task<InsuranceOrder> Add(InsuranceOrderRequest request, CancellationToken cancellationToken);
    Task<List<InsuranceOrder>> GetOrders(CancellationToken cancellationToken);
}
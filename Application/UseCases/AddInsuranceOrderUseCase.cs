using Domain.Entities;
using Domain.Interfaces;
using infrastructure.Repositories;

namespace Application.UseCases;

public class AddInsuranceOrderUseCase 
{
    private readonly IInsuranceOrderRepository _insuranceOrderRepository;

    public AddInsuranceOrderUseCase(IInsuranceOrderRepository insuranceOrderRepository)
    {
        _insuranceOrderRepository = insuranceOrderRepository;
    }

    public async Task<InsuranceOrder> Add(InsuranceOrderRequest request, CancellationToken cancellationToken)
    {
        var result = await _insuranceOrderRepository.Add(request, cancellationToken);
        return result;
    }
}
using Domain.Entities;
using Domain.Interfaces;
using infrastructure.Repositories;

namespace Application.UseCases;

public class AddInsuranceUseCase
{
    private readonly IInsuranceRepository _insuranceRepository;


    public AddInsuranceUseCase(IInsuranceRepository insuranceRepository)
    {
        _insuranceRepository = insuranceRepository;
    }

    public async Task<Insurance> Add(InsuranceRequest request, CancellationToken cancellationToken)
    {
        var result = await _insuranceRepository.Add(request, cancellationToken);
        return result;
    }
}
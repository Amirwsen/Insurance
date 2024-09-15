using Domain.Entities;
using infrastructure.Repositories;

namespace Domain.Interfaces;

public interface IInsuranceRepository
{
    Task<Insurance> Add(InsuranceRequest request, CancellationToken cancellationToken);
}
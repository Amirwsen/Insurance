using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using infrastructure.Repositories;

namespace Insurance.Controllers;

[ApiController]
public class InsuranceController : ControllerBase
{
    private readonly AddInsuranceUseCase _insuranceUsecase;

    public InsuranceController(AddInsuranceUseCase insuranceUsecase)
    {
        _insuranceUsecase = insuranceUsecase;
    }
    [HttpPost("AddInsurance")]
    public async Task<ActionResult<Domain.Entities.Insurance>> AddInsurance(InsuranceRequest request, CancellationToken cancellationToken)
    {
        var result = await _insuranceUsecase.Add(request, cancellationToken);
        return Ok(result);
    }
}
using Application.UseCases;
using Domain.Entities;
using infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers;

public class InsurancOrderController : ControllerBase
{
    private readonly AddInsuranceOrderUseCase _insuranceOrderUseCase;

    public InsurancOrderController(AddInsuranceOrderUseCase insuranceOrderUseCase)
    {
        _insuranceOrderUseCase = insuranceOrderUseCase;
    }

    [HttpPost("AddInsuranceOrder")]
    public async Task<ActionResult<InsuranceOrder>> AddInsuranceOrder(InsuranceOrderRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _insuranceOrderUseCase.Add(request, cancellationToken);
        return Ok(result);
    }
}
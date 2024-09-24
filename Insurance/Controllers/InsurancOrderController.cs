using Application.UseCases;
using Domain.Entities;
using Domain.Responses;
using infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers;

public class InsurancOrderController : ControllerBase
{
    private readonly AddInsuranceOrderUseCase _insuranceOrderUseCase;
    private readonly GetOrdersUseCase _ordersUseCase;

    public InsurancOrderController(AddInsuranceOrderUseCase insuranceOrderUseCase, GetOrdersUseCase ordersUseCase)
    {
        _insuranceOrderUseCase = insuranceOrderUseCase;
        _ordersUseCase = ordersUseCase;
    }

    [HttpPost("AddInsuranceOrder")]
    public async Task<ActionResult<InsuranceOrder>> AddInsuranceOrder(InsuranceOrderRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _insuranceOrderUseCase.Add(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetOrders")]
    public async Task<ActionResult<List<GetOrdersResponse>>> GetOrders(CancellationToken cancellationToken)
    {
        return Ok(await _ordersUseCase.GetOrders(cancellationToken));
    }
}
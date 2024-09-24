using Domain.Enums;
using Domain.Interfaces;
using Domain.Responses;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases;

public class GetOrdersUseCase
{
    private readonly IInsuranceOrderRepository _insuranceOrderRepository;
    private readonly DatabaseContext _database;

    public GetOrdersUseCase(IInsuranceOrderRepository insuranceOrderRepository, DatabaseContext database)
    {
        _insuranceOrderRepository = insuranceOrderRepository;
        _database = database;
    }

    public async Task<List<GetOrdersResponse>> GetOrders(CancellationToken cancellationToken)
    {
        var getOrder = await _database.InsuranceOrders
            .Include(order => order.Insurance)
            .ToListAsync(cancellationToken);
        foreach (var invest in getOrder)
        {
            var num = invest.Investment;
            // if (invest.Type == 0)
            // {
            //     invest.Investment = (invest.Investment * 0.0052);
            // }
            switch (invest.Type)
            {
                case (InsuranceType.Surgery):
                    invest.Investment = num * 0.0052;
                    break;
                case (InsuranceType.Dentistry):
                    invest.Investment = num * 0.0042;
                    break;
                case (InsuranceType.Hospitalization):
                    invest.Investment = num * 0.005;
                    break;
            }
        }

        var select = (await _insuranceOrderRepository.GetOrders(cancellationToken))
            .Select(x =>
            new GetOrdersResponse
            {
                Investment = x.Investment,
                Type = x.Type,
                Title = x.Insurance?.Title!
            }).ToList();

        return select;
    }
}
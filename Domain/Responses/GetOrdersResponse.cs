using Domain.Enums;

namespace Domain.Responses;

public class GetOrdersResponse
{
    public string Title { get; set; }
    public InsuranceType Type { get; set; }
    public double Investment { get; set; }
}
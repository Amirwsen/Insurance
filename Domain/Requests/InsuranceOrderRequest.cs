using Domain.Enums;

namespace infrastructure.Repositories;

public class InsuranceOrderRequest
{
    public InsuranceType Type { get; set; }
    public int Investment { get; set; }
}
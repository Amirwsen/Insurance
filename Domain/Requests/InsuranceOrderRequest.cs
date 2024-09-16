using Domain.Enums;

namespace infrastructure.Repositories;

public class InsuranceOrderRequest
{
    public Guid InsuranceId { get; set; }
    public InsuranceType Type { get; set; }
    public int Investment { get; set; }
}
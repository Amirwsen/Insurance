using Domain.Enums;

namespace Domain.Entities;

public class InsuranceOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid InsuranceId { get; set; }
    public ICollection<InsuranceType> Type { get; set; }
    public int Investment { get; set; }
}
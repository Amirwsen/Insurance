namespace Domain.Entities;

public class Insurance
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public ICollection<InsuranceOrder> InsuranceOrders { get; set; }
}
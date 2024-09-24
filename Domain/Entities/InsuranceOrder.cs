using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class InsuranceOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid InsuranceId { get; set; }
    public InsuranceType Type { get; set; }
    public double Investment { get; set; }
    public Insurance? Insurance { get; set; }
}
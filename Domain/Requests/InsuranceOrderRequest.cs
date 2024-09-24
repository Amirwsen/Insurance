using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace infrastructure.Repositories;

public class InsuranceOrderRequest
{
    public Guid InsuranceId { get; set; }
    [Required]
    public InsuranceType Type { get; set; }
    [Required, Range(2000, 50000000)]
    public double Investment { get; set; }
}
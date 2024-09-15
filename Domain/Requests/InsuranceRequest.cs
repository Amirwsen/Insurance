using Domain.Entities;
using Domain.Enums;

namespace infrastructure.Repositories;

public class InsuranceRequest
{
    public string Title { get; set; }
    public InsuranceType Type { get; set; }
    public int Investment { get; set; }}
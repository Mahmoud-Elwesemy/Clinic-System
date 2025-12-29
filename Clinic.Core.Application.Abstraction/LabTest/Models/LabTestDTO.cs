namespace Clinic.Core.Application.Abstraction.LabTest.Models;
public record LabTestDTO
{
    public int Id { get; set; }
    public string TestName { get; set; } = string.Empty;
    public string? TestResult { get; set; }
    public DateTime CreatedDate { get; set; }
}
public record AddLabTestsDTO
{
    public int VisitId { get; set; }
    public List<int>? AvailableLabTestIds { get; set; } 
}
public record UpdateLabTestsDTO
{
    public int Id { get; set; }
    public string TestName { get; set; } = string.Empty;
    public string? TestResult { get; set; }
}
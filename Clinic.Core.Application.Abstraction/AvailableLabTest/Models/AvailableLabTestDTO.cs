using System.Text.Json.Serialization;

namespace Clinic.Core.Application.Abstraction.AvailableLabTest.Models;
public record AvailableLabTestDTO
{
    public int Id { get; set; }
    public string TestName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string LabTechnicianName { get; set; } = string.Empty;
    public string LabTechnicianId { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
}
//------------------------------------------------------------------------------------------
public record AddAvailableLabTestDTO
{
    public string TestName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    [JsonIgnore]
    public string LabTechnicianId { get; set; } = string.Empty;
}
//------------------------------------------------------------------------------------------
public record UpdateAvailableLabTestDTO
{
    public int Id { get; set; }
    public string TestName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

using System.Text.Json.Serialization;

namespace Clinic.Core.Application.Abstraction.Diagnosis.Models;
public record DiagnosisDTO
{
    public int Id { get; set; }
    public string? DiagnosisText { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    [JsonIgnore]
    public int VisitId { get; set; }
}
public record AddDiagnosisDTO
{
    public string DiagnosisText { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    [JsonIgnore]
    public bool IsDeleted { get; set; }=false;   
    public int VisitId { get; set; }
}
public record UpdateDiagnosisDTO {   
    public int Id { get; set; }
    public string DiagnosisText { get; set; } = string.Empty;
}

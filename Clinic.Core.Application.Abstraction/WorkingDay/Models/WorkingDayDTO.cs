using System.Text.Json.Serialization;

namespace Clinic.Core.Application.Abstraction.WorkingDay.Models;
public record WorkingDayDTO
{    
    public int Id { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    [JsonIgnore]
    public bool IsDeleted { get; set; } = false;
    [JsonIgnore]
    public string? DoctorId { get; set; }
    [JsonIgnore]
    public string? PharmacistId { get; set; }
    [JsonIgnore]
    public string? LabTechnicianId { get; set; }
}
//------------------------------------------------------------------------------------------
public record AddWorkingDayDTO: WorkingDayDTO
{
    [JsonIgnore]
    public int Id { get; set; }
}
//------------------------------------------------------------------------------------------
public record UpdateWorkingDayDTO :WorkingDayDTO
{
}
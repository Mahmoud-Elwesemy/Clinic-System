using Clinic.Core.Domin.Entities_Helper;
using System.Text.Json.Serialization;

namespace Clinic.Core.Application.Abstraction.Appointment.Models;
public record AppointmentDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public AppointmentType appointmentType { get; set; }
    public  string? PatientName { get; set; }
    public  string? DoctorName { get; set; } 
    public bool IsDeleted { get; set; }

    [JsonIgnore]
    public string? PatientId { get; set; }
    [JsonIgnore]
    public string? DoctorId { get; set; }
}
//------------------------------------------------------------------------------------------
public record AddAppointmentDto
{
    public DateTime AppointmentDate { get; set; } = DateTime.UtcNow;   
    public PaymentType PaymentType { get; set; }
    public AppointmentType appointmentType { get; set; }

    [JsonIgnore]
    public string? PatientId { get; set; } 
    [JsonIgnore]
    public string? DoctorId { get; set; } 
    [JsonIgnore]
    public bool IsDeleted { get; set; }= false;
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public AppointmentStatus AppointmentStatus { get; set; }

}
//------------------------------------------------------------------------------------------
public record UpdateAppointmentDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }    
    public AppointmentStatus AppointmentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public AppointmentType appointmentType { get; set; }
}

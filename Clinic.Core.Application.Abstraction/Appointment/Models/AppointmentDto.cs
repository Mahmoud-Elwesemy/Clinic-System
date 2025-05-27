using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Appointment.Models;
public record AppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public AppointmentType appointmentType { get; set; }
    public  string PatientName { get; set; } = string.Empty;
    public  string DoctorName { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}
public record AddAppointmentDto
{
    [JsonIgnore]
    public DateTime AppointmentDate { get; set; } = DateTime.Now;
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public AppointmentStatus AppointmentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public AppointmentType appointmentType { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public string DoctorId { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }

};

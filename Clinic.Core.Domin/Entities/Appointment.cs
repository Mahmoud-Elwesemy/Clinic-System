using Clinic.Core.Domin.Entities.Users;
using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
// جدول الحجوزات
public class Appointment
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.Pending;
    public PaymentType PaymentType { get; set; } = PaymentType.Cash;
    public AppointmentType appointmentType { get; set; } = AppointmentType.Regular;
    public bool IsDeleted { get; set; } = false;

    // Objects From Patient With Many To One Relationship And Foreign Key Is PatientId
    [ForeignKey(nameof(Patient))]
    public string PatientId { get; set; } = string.Empty;
    public virtual Patient? Patient { get; set; } 

    // Object From Doctor With Many To One Relationship And Foreign Key Is DoctorId
    [ForeignKey(nameof(Doctor))]
    public string DoctorId { get; set; } = string.Empty;
    public virtual Doctor? Doctor { get; set; } 

    // Object From Visit With One To One Relationship (navigation property)
    public virtual Visit? Visit { get; set; }

}

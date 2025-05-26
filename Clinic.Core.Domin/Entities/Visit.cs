using Clinic.Core.Domin.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
// جدول الزياات
public class Visit
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

    // Objects From Patient With Many To One Relationship And Foreign Key Is PatientId
    [ForeignKey(nameof(Patient))]
    public string PatientId { get; set; } = string.Empty;
    public virtual Patient Patient { get; set; } = new();

    // Object From Doctor With Many To One Relationship And Foreign Key Is DoctorId
    [ForeignKey(nameof(Doctor))]
    public string DoctorId { get; set; } = string.Empty;
    public virtual Doctor Doctor { get; set; } = new();

    // Object From Appointment With Many To One Relationship And Foreign Key Is AppointmentId
    [ForeignKey(nameof(Appointment))]
    public int AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; } = new();

    // collection of Diagnosis, Treatment and LabTest with one to many relationship
    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();

}

using Clinic.Core.Domin.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
public class UserNotification
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    // Object From Doctor With Many To One Relationship And Foreign Key Is DoctorId
    [ForeignKey(nameof(Doctor))]
    public string DoctorId { get; set; } = string.Empty;
    public virtual Doctor? Doctor { get; set; }

    // Object From Pharmacist With Many To One Relationship And Foreign Key Is PharmacistId
    [ForeignKey(nameof(Pharmacist))]
    public string PharmacistId { get; set; } = string.Empty;
    public virtual Pharmacist? Pharmacist { get; set; }

    // Object From LabTechnician With Many To One Relationship And Foreign Key Is LabTechnicianId
    [ForeignKey(nameof(LabTechnician))]
    public string LabTechnicianId { get; set; } = string.Empty;
    public virtual LabTechnician? LabTechnician { get; set; }

    // Object From Receptionist With Many To One Relationship And Foreign Key Is ReceptionistId
    [ForeignKey(nameof(Receptionist))]
    public string ReceptionistId { get; set; } = string.Empty;
    public virtual Receptionist? Receptionist { get; set; }

    // Object From Patient With Many To One Relationship And Foreign Key Is PatientId
    [ForeignKey(nameof(Patient))]
    public string PatientId { get; set; } = string.Empty;
    public virtual Patient? Patient { get; set; }
}

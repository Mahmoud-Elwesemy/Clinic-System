using Clinic.Core.Domin.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
// جدول مواعيد العمل
public class WorkingDay
{
    public int Id { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
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
}

using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities.Users;
// جدول الطبيب
public class Doctor : ApplicationUser
{
    public string Specialization { get; set; } = string.Empty;
    public MedicalDegree Degree { get; set; } = MedicalDegree.Bachelor;
    public string? Biography { get; set; } = string.Empty;
    public int ConsultationDurationInMinutes { get; set; } = 30;
    public int FollowUpDurationInMinutes { get; set; } = 15;

    // Collection Of WorkingDay With One To Many Relationship
    public virtual ICollection<WorkingDay> WorkingDays { get; set; } = new List<WorkingDay>();

    // Collection Of Appointment With One To Many Relationship
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    // Collection Of UserNotification With One To Many Relationship
    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}

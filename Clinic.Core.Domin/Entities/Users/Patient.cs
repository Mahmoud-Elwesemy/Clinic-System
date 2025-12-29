using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities.Users;
//جدول المرضي
public class Patient : ApplicationUser
{
    [MaxLength(14)]
    public string? NationalId { get; set; } 
    public string? Address { get; set; } = string.Empty;
    public BloodType? BloodType { get; set; } 
    public DateTime? BirthDate { get; set; } = DateTime.UtcNow;


    // collection of Visits, Appointments with one to many relationship
    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    // collection of Appointments with one to many relationship
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    // Collection Of UserNotification With One To Many Relationship
    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}

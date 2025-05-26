using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities.Users;
// جدول موظف معمل التحاليل
public class LabTechnician : ApplicationUser
{

    // Collection Of WorkingDay With One To Many Relationship
    public virtual ICollection<WorkingDay>? WorkingDays { get; set; }

    // Collection Of AvailableLabTest With One To Many Relationship
    public virtual ICollection<AvailableLabTest>? AvailableLabTests { get; set; }

    // Collection Of UserNotification With One To Many Relationship
    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities.Users;
// جدول الصيدلي
public class Pharmacist : ApplicationUser
{

    // Collection Of WorkingDay With One To Many Relationship
    public virtual ICollection<WorkingDay>? WorkingDays { get; set; }

    // Collection Of Medicine With One To Many Relationship
    public virtual ICollection<Medicine>? Medicines { get; set; }

    // Collection Of UserNotification With One To Many Relationship
    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}

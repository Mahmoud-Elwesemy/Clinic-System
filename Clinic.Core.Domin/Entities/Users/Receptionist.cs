using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities.Users;
// جدول موظف الاستقبال
public class Receptionist : ApplicationUser
{
    public virtual WorkShift? workShift { get; set; }

    // Collection Of UserNotification With One To Many Relationship
    public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
}

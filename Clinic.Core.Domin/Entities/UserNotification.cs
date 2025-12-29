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

    // Object From User With Many To One Relationship And Foreign Key Is UserId
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;
    public virtual ApplicationUser User { get; set; } = null!;
}

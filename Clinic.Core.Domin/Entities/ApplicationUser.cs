using Clinic.Core.Domin.Entities_Helper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
public class ApplicationUser:IdentityUser
{
    public ApplicationUser()
    {
        Id = Guid.CreateVersion7().ToString();
        SecurityStamp = Guid.CreateVersion7().ToString();
    }
    [Required]
    public string FullName { get; set; }= string.Empty;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public byte[]? ProfilePicture { get; set; }
    public Gender Gender { get; set; }
    public string? WhatsAppNumber { get; set; }

}

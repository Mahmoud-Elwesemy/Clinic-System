using Clinic.Core.Domin.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
public class AvailableLabTest
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string TestName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

    // Object From LabTechnician With Many To One Relationship And Foreign Key Is LabTechnicianId
    [ForeignKey(nameof(LabTechnician))]
    public string LabTechnicianId { get; set; } = string.Empty;
    public virtual LabTechnician LabTechnician { get; set; } = new();

    // Collection Of LabTest With One To Many Relationship
    public virtual ICollection<LabTest>? LabTests { get; set; }

}

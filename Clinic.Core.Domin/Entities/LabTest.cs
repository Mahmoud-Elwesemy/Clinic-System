using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
// جدول التحاليل
public class LabTest
{
    public int Id { get; set; }
    public string TestName => AvailableLabTest?.TestName ?? string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string? TestResult { get; set; }
    public bool IsDeleted { get; set; } = false;

    // Object From Visit With Many To One Relationship And Foreign Key Is VisitId
    [ForeignKey(nameof(Visit))]
    public int VisitId { get; set; }
    public virtual Visit? Visit { get; set; } 

    // Object From AvailableLabTest With Many To One Relationship And Foreign Key Is AvailableLabTestId
    [ForeignKey(nameof(AvailableLabTest))]
    public int AvailableLabTestId { get; set; }
    public virtual AvailableLabTest? AvailableLabTest { get; set; } 
}

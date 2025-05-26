using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
// جدول التشخيصات
public class Diagnosis
{
    public int Id { get; set; }
    public string DiagnosisText { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

    // Object From Visit With Many To One Relationship And Foreign Key Is VisitId
    [ForeignKey(nameof(Visit))]
    public int VisitId { get; set; }
    public virtual Visit Visit { get; set; } = new();
}

using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
// جدول العلاجات
public class Treatment
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public PrescriptionStatus PrescriptionStatus { get; set; } = PrescriptionStatus.Pending;
    public bool IsDeleted { get; set; } = false;

    // Object From Visit With Many To One Relationship And Foreign Key Is VisitId
    [ForeignKey(nameof(Visit))]
    public int VisitId { get; set; }
    public virtual Visit Visit { get; set; } = new Visit();

    // Collection Of TreatmentMedicine With One To Many Relationship
    public virtual ICollection<TreatmentMedicine> TreatmentMedicines { get; set; } = new List<TreatmentMedicine>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
public class TreatmentMedicine
{
    public int Id { get; set; }
    [Required]
    public string Dosage { get; set; } = string.Empty;
    [Required]
    public string Instructions { get; set; } = string.Empty;

    // Object From Treatment With Many To One Relationship And Foreign Key Is TreatmentId
    [ForeignKey(nameof(Treatment))]
    public int TreatmentId { get; set; }
    public virtual Treatment Treatment { get; set; } = null!;

    // Object From Medicine With Many To One Relationship And Foreign Key Is MedicineId
    [ForeignKey(nameof(Medicine))]
    public int MedicineId { get; set; }
    public virtual Medicine Medicine { get; set; } = null!;


}

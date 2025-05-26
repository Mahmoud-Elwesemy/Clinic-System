using Clinic.Core.Domin.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities;
public class Medicine
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal? Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;


    // Object From Pharmacist With Many To One Relationship And Foreign Key Is PharmacistId
    [ForeignKey(nameof(Pharmacist))]
    public string PharmacistId { get; set; } = string.Empty;
    public virtual Pharmacist? Pharmacist { get; set; }

    // Collection Of TreatmentMedicine With One To Many Relationship
    public virtual ICollection<TreatmentMedicine> TreatmentMedicines { get; set; } = new List<TreatmentMedicine>();
}

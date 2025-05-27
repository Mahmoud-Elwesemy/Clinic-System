using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Medicine.Models;
public record MedicineDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal? Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public string PharmacistName { get; set; } = string.Empty;
}
public record AddMedicineDTO
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal? Price { get; set; }
    [JsonIgnore]
    public string PharmacistId { get; set; } = string.Empty;
}
public record UpdateMedicineDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int QuantityAvailable { get; set; }
    public decimal? Price { get; set; }
}

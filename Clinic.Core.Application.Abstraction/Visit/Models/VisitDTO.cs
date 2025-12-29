using Clinic.Core.Application.Abstraction.Diagnosis.Models;
using Clinic.Core.Application.Abstraction.LabTest.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Visit.Models;
public record VisitDTO
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    [JsonIgnore]
    public int AppointmentId { get; set; }
    [JsonIgnore]
    public string PatientId { get; set; } = string.Empty;
    [JsonIgnore]
    public string DoctorId { get; set; } = string.Empty;
    public string? PatientFullName { get; set; }
    public string? DoctorFullName { get; set; }
    public List<DiagnosisDTO>? Diagnoses { get; set; }  
    public List<TreatmentDTO>? Treatments { get; set; } 
    public List<LabTestDTO>? LabTests { get; set; } 
}
//------------------------------------------------------------------------------------------
public record AddVisitDTO
{
    [JsonIgnore]
    public int AppointmentId { get; set; }
    [JsonIgnore]
    public string PatientId { get; set; } = string.Empty;
    [JsonIgnore]
    public string DoctorId { get; set; } = string.Empty;
}
//------------------------------------------------------------------------------------------
public record UpdateVisitDTO
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
}
//------------------------------------------------------------------------------------------
//public record DiagnosisDTO
//{
//    public int Id { get; set; }
//    public string DiagnosisText { get; set; } = string.Empty;
//    public DateTime CreatedAt { get; set; }
//}
public record TreatmentDTO
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public PrescriptionStatus PrescriptionStatus { get; set; }
}
//public record LabTestDTO
//{
//    public int Id { get; set; }
//    public string TestName { get; set; } = string.Empty;
//    public string? TestResult { get; set; }
//    public DateTime CreatedDate { get; set; }
//}

using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Application.Abstraction.Visit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Visit;
public interface IVisitService
{
    Task<IEnumerable<VisitDTO>> GetAllVisitsAsync();
    Task<IEnumerable<VisitDTO>> GetPatientVisitsAsync(string patientId);
    Task<IEnumerable<VisitDTO>> GetPatientVisitsIncludingDeletedAsync(string patientId);
    Task<VisitDTO> GetVisitByIdAsync(int visitId);
    Task CreateVisitForAppointmentAsync(int appointmentId);
    Task<VisitDTO> UpdateVisitAsync(UpdateVisitDTO dto);
    Task HardDeleteVisitAsync(int id);
    Task SoftDeleteVisitAsync(int id);
    Task RestoreVisitAsync(int id);
}


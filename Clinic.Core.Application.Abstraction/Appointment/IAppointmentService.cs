using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Appointment;
public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentAsync();
    Task<IEnumerable<AppointmentDto>> GetAllIncludingDeletedAsync();
    Task<IEnumerable<AppointmentDto>> GetDeletedOnlyAsync();
    Task<MedicineDTO> GetAppointmentByIdAsync(int id);
    Task AddAppointmentAsync(AddAppointmentDto Entity);
    void UpdateAppointmentAsync(UpdateMedicineDTO Entity);
    Task HardDeleteAppointmentAsync(int id);
    Task SoftDeleteAppointmentAsync(int id);
    Task RestoreAppointmentAsync(int id);
}

using Clinic.Core.Application.Abstraction.Appointment.Models;

namespace Clinic.Core.Application.Abstraction.Appointment;
public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentAsync();
    Task<IEnumerable<AppointmentDto>> GetTodayAppointmentsForDoctorAsync();
    Task<IEnumerable<AppointmentDto>> GetAllIncludingDeletedAsync();
    Task<IEnumerable<AppointmentDto>> GetDeletedOnlyAsync();
    Task<AppointmentDto> GetAppointmentByIdAsync(int id);
    Task AddAppointmentAsync(AddAppointmentDto Entity);
    Task UpdateAppointmentAsync(UpdateAppointmentDto Entity);
    Task HardDeleteAppointmentAsync(int id);
    Task SoftDeleteAppointmentAsync(int id);
    //Task RestoreAppointmentAsync(int id);
    Task<IEnumerable<DateTime>> GetAvailableSlotsAsync(DateTime date);
    Task<bool> IsSlotAvailable(DateTime slot);
}

using Clinic.Core.Domin.Entities;

namespace Clinic.Core.Domin.Repositories.contract;
public interface IAppointmentRepository:IGenericRepository<Appointment,int>
{
    Task<IEnumerable<DateTime>> GetAvailableSlotsAsync(DateTime date);
    Task<bool> IsSlotAvailable(DateTime slot);
}



using Clinic.Core.Application.Abstraction.WorkingDay.Models;
using Clinic.Core.Domin.Entities_Helper;

namespace Clinic.Core.Application.Abstraction.WorkingDay;
public interface IWorkingDayService
{
    Task<IEnumerable<WorkingDayDTO>> GetMyWorkingDaysOrByTypeAsync(WorkingDayType? type = null);
    //Task<IEnumerable<WorkingDayDTO>> GetGetAllWorkingDay();
    Task<IEnumerable<WorkingDayDTO>> GetAllIncludingDeletedAsync();
    Task<IEnumerable<WorkingDayDTO>> GetAllSoftDeletedAsync();
    Task<WorkingDayDTO> GetWorkingDayByIdAsync(int id);
    Task AddWorkingDayAsync(AddWorkingDayDTO Entity);
    Task UpdateWorkingDayAsync(UpdateWorkingDayDTO Entity);
    Task HardDeleteWorkingDayAsync(int id);
    Task SoftDeleteWorkingDayAsync(int id);
    Task RestoreWorkingDayAsync(int id);
}

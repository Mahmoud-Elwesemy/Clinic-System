using Clinic.Core.Application.Abstraction.AvailableLabTest.Models;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.AvailableLabTest;
public interface IAvailableLabTestService
{
    Task<IEnumerable<AvailableLabTestDTO>> GetAllAvailableLabTestAsync();
    Task<IEnumerable<AvailableLabTestDTO>> GetAllIncludingDeletedAsync();
    Task<IEnumerable<AvailableLabTestDTO>> GetDeletedOnlyAsync();
    Task<AvailableLabTestDTO> GetAvailableLabTestByIdAsync(int id);
    Task AddAvailableLabTestAsync(AddAvailableLabTestDTO Entity);
    Task UpdateAvailableLabTestAsync(UpdateAvailableLabTestDTO Entity);
    Task HardDeleteAvailableLabTestAsync(int id);
    Task SoftDeleteAvailableLabTestAsync(int id);
    Task RestoreAvailableLabTestAsync(int id);
}

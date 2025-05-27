using Clinic.Core.Application.Abstraction.Medicine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Abstraction.Medicine;
public interface IMedicineService
{
    Task<IEnumerable<MedicineDTO>> GetMedicinesAsync();
    Task<IEnumerable<MedicineDTO>> GetAllIncludingDeletedAsync();
    Task<IEnumerable<MedicineDTO>> GetDeletedOnlyAsync();
    Task<MedicineDTO> GetMedicineByIdAsync(int id);
    Task AddMedicineAsync(AddMedicineDTO Entity);
    Task UpdateMedicineAsync(UpdateMedicineDTO Entity);
    Task HardDeleteMedicineAsync(int id);
    Task SoftDeleteMedicineAsync(int id);
    Task RestoreMedicineAsync(int id);
}

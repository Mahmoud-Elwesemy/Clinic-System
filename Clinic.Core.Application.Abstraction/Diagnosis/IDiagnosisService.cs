using Clinic.Core.Application.Abstraction.Diagnosis.Models;

namespace Clinic.Core.Application.Abstraction.Diagnosis;
public interface IDiagnosisService
{
    //Task<IEnumerable<DiagnosisDTO>> GetOnlyDeletedDiagnosisAsync();
    Task CreateDiagnosisAsync(AddDiagnosisDTO dto);
    Task UpdateDiagnosisAsync(UpdateDiagnosisDTO dto);
    Task HardDeleteDiagnosisAsync(int DiagnosisId);
    //Task SoftDeleteDiagnosisAsync(int DiagnosisId);
    //Task RestoreDiagnosisAsync(int DiagnosisId);
}

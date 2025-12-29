using AutoMapper;
using Clinic.Core.Application.Abstraction.Diagnosis;
using Clinic.Core.Application.Abstraction.Diagnosis.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.UnitOfWork.Contract;

namespace Clinic.Core.Application.Services.DiagnosisServices;
internal class DiagnosisService(IUnitOfWork unitOfWork,IMapper mapper):IDiagnosisService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    //-----------------------------------------------------------------------------------
    //public async Task<IEnumerable<DiagnosisDTO>> GetOnlyDeletedDiagnosisAsync()
    //{
    //    var result = await _unitOfWork.GetRepository<Diagnosis,int>().GetDeletedOnlyAsync();
    //    return _mapper.Map<IEnumerable<DiagnosisDTO>>(result);
    //}
    //-----------------------------------------------------------------------------------
    public async Task CreateDiagnosisAsync(AddDiagnosisDTO dto)
    {
        if(dto == null)
            throw new KeyNotFoundException("الوصفه العلاجيه فارغه");
        var Visit = await _unitOfWork.GetRepository<Visit,int>().GetByIdAsync(dto.VisitId);
        if(Visit == null)
            throw new KeyNotFoundException("الزياره غير موجود");
        
        var diagnosis = new Diagnosis
        {
            VisitId = Visit.Id,
            DiagnosisText = dto.DiagnosisText,
        };
        await _unitOfWork.GetRepository<Diagnosis,int>().AddAsync(diagnosis);
        await _unitOfWork.CompleteAsync();        
    }
    //-----------------------------------------------------------------------------------
    public async Task UpdateDiagnosisAsync(UpdateDiagnosisDTO dto)
    {
        var repo = _unitOfWork.GetRepository<Diagnosis,int>();
        var diagnosis = await repo.GetByIdAsync(dto.Id);
        if(diagnosis == null || diagnosis.IsDeleted)
            throw new KeyNotFoundException($"التشخيص بالمعرف {dto.Id} غير موجودة");
        diagnosis.DiagnosisText = dto.DiagnosisText;
        _mapper.Map(dto,diagnosis);
        repo.UpdateAsync(diagnosis);
        await _unitOfWork.CompleteAsync();      
    }
    //-----------------------------------------------------------------------------------
    public async Task HardDeleteDiagnosisAsync(int DiagnosisId)
    {
        var repo = _unitOfWork.GetRepository<Diagnosis,int>();
        var diagnosis = await repo.GetByIdAsync(DiagnosisId);
        if(diagnosis == null )
            throw new KeyNotFoundException($"التشخيص بالمعرف {DiagnosisId} غير موجودة");
        await repo.HardDeleteAsync(DiagnosisId);
        await _unitOfWork.CompleteAsync();
    }
    //-----------------------------------------------------------------------------------
    //public async Task SoftDeleteDiagnosisAsync(int DiagnosisId)
    //{
    //    var repo = _unitOfWork.GetRepository<Diagnosis,int>();
    //    var diagnosis = await repo.GetByIdAsync(DiagnosisId);
    //    if(diagnosis == null )
    //        throw new KeyNotFoundException($"التشخيص بالمعرف {DiagnosisId} غير موجودة");
    //    await repo.SoftDeleteAsync(DiagnosisId);
    //    await _unitOfWork.CompleteAsync();
    //}
    //-----------------------------------------------------------------------------------
    //public async Task RestoreDiagnosisAsync(int DiagnosisId)
    //{
    //    var repo = _unitOfWork.GetRepository<Diagnosis,int>();
    //    var diagnosis = await repo.GetByIdAsync(DiagnosisId);
    //    if(diagnosis == null )
    //        throw new KeyNotFoundException($"التشخيص بالمعرف {DiagnosisId} غير موجودة");
    //    await repo.RestoreByIdAsync(DiagnosisId);
    //    await _unitOfWork.CompleteAsync();
    //}    
    //-----------------------------------------------------------------------------------
}

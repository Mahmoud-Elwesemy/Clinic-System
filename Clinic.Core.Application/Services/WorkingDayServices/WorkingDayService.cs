using AutoMapper;
using Clinic.Core.Application.Abstraction.WorkingDay;
using Clinic.Core.Application.Abstraction.WorkingDay.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Clinic.Core.Application.Services.WorkingDayServices;
internal class WorkingDayService(IUnitOfWork unitOfWork,IMapper mapper ,IHttpContextAccessor httpContextAccessor):IWorkingDayService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    //------------------------------------------------------------------------------------------
    private string UserId => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    private string Role => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;

    private void EnsureAuthorized()
    {
        if(string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Role))
            throw new UnauthorizedAccessException("User is not authorized");
    }

    private bool IsWorkingDayConflict(IEnumerable<WorkingDay> allDays,DayOfWeek day,int? excludeId = null)
    {
        return allDays.Any(w =>
            (!excludeId.HasValue || w.Id != excludeId.Value) &&
            w.Day == day &&
            !w.IsDeleted &&
            (
                (Role == "Doctor" && w.DoctorId == UserId) ||
                (Role == "Pharmacist" && w.PharmacistId == UserId) ||
                (Role == "LabTechnician" && w.LabTechnicianId == UserId)
            )
        );
    }
    //--------------------------------------------------------------------------------------
    public async Task<IEnumerable<WorkingDayDTO>> GetMyWorkingDaysOrByTypeAsync(WorkingDayType? type = null)
    {
        EnsureAuthorized();

        var repo = await _unitOfWork.GetRepository<WorkingDay,int>().GetAllAsync();
        var query = repo.AsQueryable();

        if(Role == "Patient")
        {
            if(type == null)
                throw new ArgumentNullException(nameof(type),"Type is required for patient.");

            query = type switch
            {
                WorkingDayType.Doctor => query.Where(w => w.DoctorId != null && !w.IsDeleted),
                WorkingDayType.Pharmacist => query.Where(w => w.PharmacistId != null && !w.IsDeleted),
                WorkingDayType.LabTechnician => query.Where(w => w.LabTechnicianId != null && !w.IsDeleted),
                _ => throw new ArgumentException("Invalid working day type for patient.")
            };
        }
        else
        {
            query = Role switch
            {
                "Doctor" => query.Where(w => w.DoctorId == UserId && !w.IsDeleted),
                "Pharmacist" => query.Where(w => w.PharmacistId == UserId && !w.IsDeleted),
                "LabTechnician" => query.Where(w => w.LabTechnicianId == UserId && !w.IsDeleted),
                _ => throw new UnauthorizedAccessException("Invalid role for this operation.")
            };
        }

        var results = query.ToList();
        return _mapper.Map<IEnumerable<WorkingDayDTO>>(results);
    }
    //--------------------------------------------------------------------------------------
    //public async Task<IEnumerable<WorkingDayDTO>> GetGetAllWorkingDay()
    //{
    //    var WorkingDay = await _unitOfWork.GetRepository<WorkingDay,int>().GetAllAsync();
    //    return _mapper.Map<IEnumerable<WorkingDayDTO>>(WorkingDay);
    //}
    //--------------------------------------------------------------------------------------
    public async Task<WorkingDayDTO> GetWorkingDayByIdAsync(int id)
    {
        var WorkingDay = await _unitOfWork.GetRepository<WorkingDay,int>().GetByIdAsync(id);
        if (WorkingDay == null)
            throw new KeyNotFoundException($"WorkingDay with ID {id} not found.");

        return _mapper.Map<WorkingDayDTO>(WorkingDay);
    }
    //--------------------------------------------------------------------------------------
    public async Task<IEnumerable<WorkingDayDTO>> GetAllIncludingDeletedAsync()
    {
        EnsureAuthorized();

        var workingDays = await _unitOfWork.GetRepository<WorkingDay,int>().GetAllIncludingDeletedAsync();
        var filtered = workingDays.Where(w =>
            (Role == "Doctor" && w.DoctorId == UserId) ||
            (Role == "Pharmacist" && w.PharmacistId == UserId) ||
            (Role == "LabTechnician" && w.LabTechnicianId == UserId)
        );

        return _mapper.Map<IEnumerable<WorkingDayDTO>>(filtered);
    }
    //--------------------------------------------------------------------------------------
    public async Task<IEnumerable<WorkingDayDTO>> GetAllSoftDeletedAsync()
    {
        EnsureAuthorized();

        var workingDays = await _unitOfWork.GetRepository<WorkingDay,int>().GetDeletedOnlyAsync();
        var filtered = workingDays.Where(w =>
            (Role == "Doctor" && w.DoctorId == UserId) ||
            (Role == "Pharmacist" && w.PharmacistId == UserId) ||
            (Role == "LabTechnician" && w.LabTechnicianId == UserId)
        );

        return _mapper.Map<IEnumerable<WorkingDayDTO>>(filtered);
    }
    //--------------------------------------------------------------------------------------
    public async Task AddWorkingDayAsync(AddWorkingDayDTO dto)
    {
        if(dto == null)
            throw new ArgumentNullException(nameof(dto),"Entity cannot be null");
        EnsureAuthorized();
        var allDays = await _unitOfWork.GetRepository<WorkingDay,int>().GetAllAsync();

        if(IsWorkingDayConflict(allDays,dto.Day))
            throw new InvalidOperationException("This Day Already Exists.");

        _ = Role switch
        {
            "Doctor" => dto.DoctorId = UserId,
            "Pharmacist" => dto.PharmacistId = UserId,
            "LabTechnician" => dto.LabTechnicianId = UserId,
            _ => throw new UnauthorizedAccessException("Only medical staff can perform this operation.")
        };

        var entity = _mapper.Map<WorkingDay>(dto);
        await _unitOfWork.GetRepository<WorkingDay,int>().AddAsync(entity);
        await _unitOfWork.CompleteAsync();

    }
    //--------------------------------------------------------------------------------------
    public async Task UpdateWorkingDayAsync(UpdateWorkingDayDTO dto)
    {
        var workingDayRepo = _unitOfWork.GetRepository<WorkingDay, int>();
        var existing = await workingDayRepo.GetByIdAsync(dto.Id);
        if (existing == null)
            throw new KeyNotFoundException($"WorkingDay with ID {dto.Id} not found.");

        EnsureAuthorized();

        var allDays = await workingDayRepo.GetAllAsync();

        if(IsWorkingDayConflict(allDays,dto.Day,dto.Id))
            throw new InvalidOperationException("This Day Already Exists for you.");

        _ = Role switch
        {
            "Doctor" => dto.DoctorId = UserId,
            "Pharmacist" => dto.PharmacistId = UserId,
            "LabTechnician" => dto.LabTechnicianId = UserId,
            _ => throw new UnauthorizedAccessException("Only medical staff can perform this operation.")
        };

        _mapper.Map(dto, existing);
        workingDayRepo.UpdateAsync(existing);
        await _unitOfWork.CompleteAsync();
    }
    //--------------------------------------------------------------------------------------
    public async Task HardDeleteWorkingDayAsync(int id)
    {
        await _unitOfWork.GetRepository<WorkingDay,int>().HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //--------------------------------------------------------------------------------------
    public async Task SoftDeleteWorkingDayAsync(int id)
    {
        await _unitOfWork.GetRepository<WorkingDay ,int>().SoftDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //--------------------------------------------------------------------------------------
    public async Task RestoreWorkingDayAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<WorkingDay,int>();
        var toRestore = await repo.GetByIdAsync(id);

        if(toRestore == null)
            throw new KeyNotFoundException($"WorkingDay with ID {id} not found.");

        if(!toRestore.IsDeleted)
            throw new InvalidOperationException("This working day is already active.");

        EnsureAuthorized();
        var allDays = await repo.GetAllAsync();

        if(IsWorkingDayConflict(allDays,toRestore.Day,toRestore.Id))
            throw new InvalidOperationException("Cannot restore: an active working day with the same day already exists.");

        await repo.RestoreByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //--------------------------------------------------------------------------------------
}

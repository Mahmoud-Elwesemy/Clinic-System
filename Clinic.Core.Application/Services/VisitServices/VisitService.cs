using AutoMapper;
using Clinic.Core.Application.Abstraction.Visit;
using Clinic.Core.Application.Abstraction.Visit.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Services.VisitServices;
internal class VisitService(IUnitOfWork unitOfWork,IMapper mapper):IVisitService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    //------------------------------------------------------------------------------------
    public async Task<IEnumerable<VisitDTO>> GetAllVisitsAsync()
    {
        return _mapper.Map<IEnumerable<VisitDTO>>(await _unitOfWork.GetRepository<Visit,int>().GetAllAsync());
    }
    //-------------------------------------------------------------------------------------
    public async Task<IEnumerable<VisitDTO>> GetPatientVisitsAsync(string patientId)
    {
        var visits = await _unitOfWork.GetRepository<Visit,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<VisitDTO>>(
        visits.Where(v => v.PatientId == patientId && !v.IsDeleted)
    );
    }
    //-------------------------------------------------------------------------------------
    public async Task<IEnumerable<VisitDTO>> GetPatientVisitsIncludingDeletedAsync(string patientId)
    {
        var visits = await _unitOfWork.GetRepository<Visit,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<VisitDTO>>(
        visits.Where(v => v.PatientId == patientId && v.IsDeleted==true)
    );
    }
    //-------------------------------------------------------------------------------------
    public async Task<VisitDTO> GetVisitByIdAsync(int visitId)
    {
        return _mapper.Map<VisitDTO>(await _unitOfWork.GetRepository<Visit,int>().GetByIdAsync(visitId));
    }
    //-------------------------------------------------------------------------------------
    public async Task CreateVisitForAppointmentAsync(int appointmentId)
    {
        var appointment = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(appointmentId);
        if(appointment == null)
            throw new KeyNotFoundException("الحجز غير موجود");

        if(appointment.Visit != null)
            throw new InvalidOperationException("تم إنشاء زيارة بالفعل لهذا الحجز");

        if(string.IsNullOrEmpty(appointment.DoctorId) || string.IsNullOrEmpty(appointment.PatientId))
            throw new InvalidOperationException("الحجز غير مكتمل - المريض أو الطبيب غير معرف");

        var visit = new Visit
        {
            AppointmentId = appointment.Id,
            DoctorId = appointment.DoctorId,
            PatientId = appointment.PatientId,
        };
        await _unitOfWork.GetRepository<Visit,int>().AddAsync(visit);
        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------------
    public async Task<VisitDTO> UpdateVisitAsync(UpdateVisitDTO dto)
    {
        var repo = _unitOfWork.GetRepository<Visit,int>();
        var visit = await repo.GetByIdAsync(dto.Id);
        if(visit == null || visit.IsDeleted)
            throw new KeyNotFoundException($"الزيارة بالمعرف {dto.Id} غير موجودة");
        visit.VisitDate = dto.VisitDate;
        repo.UpdateAsync(visit);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<VisitDTO>(visit);
    }
    //-------------------------------------------------------------------------------------
    public async Task HardDeleteVisitAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<Visit,int>();
        var visit = await repo.GetByIdAsync(id);
        if(visit == null)
            throw new KeyNotFoundException($"الزيارة بالمعرف {id} غير موجودة");

        await repo.HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------------
    public async Task SoftDeleteVisitAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<Visit,int>();
        var visit = await repo.GetByIdAsync(id);
        if(visit == null)
            throw new KeyNotFoundException($"الزيارة بالمعرف {id} غير موجودة");

        await repo.SoftDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------------
    public async Task RestoreVisitAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<Visit,int>();
        var visit = await repo.GetByIdAsync(id);
        if(visit == null)
            throw new KeyNotFoundException($"الزيارة بالمعرف {id} غير موجودة");

        await repo.RestoreByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //-------------------------------------------------------------------------------------
}

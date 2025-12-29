using AutoMapper;
using Clinic.Core.Application.Abstraction.Appointment;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Clinic.Core.Application.Services.AppointmentServices;
public class AppointmentService(IUnitOfWork unitOfWork,IMapper mapper ,IHttpContextAccessor httpContextAccessor ):IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;    
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentAsync()
    {
        var appointments = await _unitOfWork.GetAppointmentRepository().GetAllAsync();
        var result = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);       
        return result;
    }
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<AppointmentDto>> GetTodayAppointmentsForDoctorAsync()
    {
        var doctorId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(string.IsNullOrEmpty(doctorId))
            throw new UnauthorizedAccessException("Doctor not authenticated");

        var today = DateTime.Today;
        var appointments = await _unitOfWork.GetAppointmentRepository().GetAllAsync();

        var todayAppointments = appointments
            .Where(a => a.DoctorId == doctorId
                     && !a.IsDeleted
                     && a.AppointmentDate.Date == today)
            .ToList();

        return _mapper.Map<IEnumerable<AppointmentDto>>(todayAppointments);
    }
    //------------------------------------------------------------------------------------------
    public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
    {
       var  appointment = await _unitOfWork.GetAppointmentRepository().GetByIdAsync(id);
        if( appointment == null)
        {
            throw new KeyNotFoundException($"Appointment with ID {id} not found.");
        }
        var result = _mapper.Map<AppointmentDto>(appointment);       
        return result;
    }
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<AppointmentDto>> GetAllIncludingDeletedAsync()
    {
        var result =await _unitOfWork.GetAppointmentRepository().GetAllIncludingDeletedAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(result);
    }
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<AppointmentDto>> GetDeletedOnlyAsync()
    {
        var result =await _unitOfWork.GetAppointmentRepository().GetDeletedOnlyAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(result);
    }
    //------------------------------------------------------------------------------------------
    public async Task AddAppointmentAsync(AddAppointmentDto Entity)
    {
        Entity.DoctorId = DefaultUser.DoctorId;
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        if(string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("User is not authorized");
        Entity.PatientId = userId;
        bool isAvailable = await IsSlotAvailable(Entity.AppointmentDate);
        if(!isAvailable)
            throw new InvalidOperationException("Selected time slot is no longer available");
        var appointment = _mapper.Map<Appointment>(Entity);
        await _unitOfWork.GetAppointmentRepository().AddAsync(appointment);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task UpdateAppointmentAsync(UpdateAppointmentDto Entity)
    {
        var appointmentRepo = _unitOfWork.GetAppointmentRepository();
        var existingAppointment = await appointmentRepo.GetByIdAsync(Entity.Id );
        if(existingAppointment == null)
            throw new KeyNotFoundException($"Appointment with ID {Entity.Id} not found.");
        if(existingAppointment.AppointmentDate != Entity.AppointmentDate)
        {
            bool isAvailable = await IsSlotAvailable(Entity.AppointmentDate);
            if(!isAvailable)
                throw new InvalidOperationException("Selected time slot is no longer available");
        }
        _mapper.Map(Entity,existingAppointment);
        appointmentRepo.UpdateAsync(existingAppointment);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task HardDeleteAppointmentAsync(int id)
    {
        await _unitOfWork.GetAppointmentRepository().HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    public async Task SoftDeleteAppointmentAsync(int id)
    {
        var appointmentRepository = _unitOfWork.GetAppointmentRepository();
        var existingAppointment = await appointmentRepository.GetByIdAsync(id);
        if(existingAppointment == null)
            throw new KeyNotFoundException($"Appointment with ID {id} not found.");
        existingAppointment.AppointmentStatus = AppointmentStatus.Cancelled;
        await appointmentRepository.SoftDeleteAsync(id);
        appointmentRepository.UpdateAsync(existingAppointment);
        await _unitOfWork.CompleteAsync();
    }
    //------------------------------------------------------------------------------------------
    // اظن اني مش محتاج اني اعمل اعادة لاي حجز اتعملو الغاء 
    //public async Task RestoreAppointmentAsync(int id)
    //{
    //    await _unitOfWork.GetAppointmentRepository().RestoreByIdAsync(id);
    //    await _unitOfWork.CompleteAsync();
    //}
    //------------------------------------------------------------------------------------------
    public async Task<IEnumerable<DateTime>> GetAvailableSlotsAsync(DateTime date)
    {
        
        return await _unitOfWork.GetAppointmentRepository().GetAvailableSlotsAsync(date);
    }
    //------------------------------------------------------------------------------------------
    public async Task<bool> IsSlotAvailable(DateTime slot)
    {
        return await _unitOfWork.GetAppointmentRepository().IsSlotAvailable(slot);
    }  
    //------------------------------------------------------------------------------------------
}

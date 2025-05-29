using AutoMapper;
using Clinic.Core.Application.Abstraction.Appointment;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities.Users;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Clinic.Infrastructure.Presistence.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Services.AppointmentServices;
public class AppointmentService(IUnitOfWork unitOfWork,IMapper mapper ,IHttpContextAccessor httpContextAccessor):IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    //------------------------------------------------------------------------------------------
    
    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentAsync()
    {
        var appointments = await _unitOfWork.GetRepository<Appointment,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
       
    }
    public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
    {
       var result =await _unitOfWork.GetRepository<Appointment,int>().GetByIdAsync(id);
        if(result == null)
        {
            throw new KeyNotFoundException($"Appointment with ID {id} not found.");
        }
        return _mapper.Map<AppointmentDto>(result);
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllIncludingDeletedAsync()
    {
        var result =await _unitOfWork.GetRepository<Appointment,int>().GetAllIncludingDeletedAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(result);
    }

    public async Task<IEnumerable<AppointmentDto>> GetDeletedOnlyAsync()
    {
        var result =await _unitOfWork.GetRepository<Appointment,int>().GetDeletedOnlyAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(result);
    }
    public async Task AddAppointmentAsync(AddAppointmentDto Entity)
    {
        Entity.DoctorId = DefaultUser.DoctorId;
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        if(string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("User is not authorized");
        Entity.PatientId = userId;
        var appointment = _mapper.Map<Appointment>(Entity);
        await _unitOfWork.GetRepository<Appointment,int>().AddAsync(appointment);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAppointmentAsync(UpdateAppointmentDto Entity)
    {
        var appointmentRepo = _unitOfWork.GetRepository<Appointment,int>();
        var existingAppointment = await appointmentRepo.GetByIdAsync(Entity.Id);
        if(existingAppointment == null)
        {
            throw new KeyNotFoundException($"Appointment with ID {Entity.Id} not found.");
        }
        _mapper.Map(Entity,existingAppointment);
        appointmentRepo.UpdateAsync(existingAppointment);
        await _unitOfWork.CompleteAsync();
    }

    public async Task HardDeleteAppointmentAsync(int id)
    {
        await _unitOfWork.GetRepository<Appointment,int>().HardDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RestoreAppointmentAsync(int id)
    {
        await _unitOfWork.GetRepository<Appointment,int>().RestoreByIdAsync(id);
        await _unitOfWork.CompleteAsync();
    }

    public async Task SoftDeleteAppointmentAsync(int id)
    {
       await _unitOfWork.GetRepository<Appointment,int>().SoftDeleteAsync(id);
       await _unitOfWork.CompleteAsync();
    }

}

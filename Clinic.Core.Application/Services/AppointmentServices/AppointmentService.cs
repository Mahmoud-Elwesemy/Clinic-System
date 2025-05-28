using AutoMapper;
using Clinic.Core.Application.Abstraction.Appointment;
using Clinic.Core.Application.Abstraction.Appointment.Models;
using Clinic.Core.Application.Abstraction.Medicine.Models;
using Clinic.Core.Domin.Entities;
using Clinic.Core.Domin.Entities_Helper;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Clinic.Infrastructure.Presistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Application.Services.AppointmentServices;
public class AppointmentService(IUnitOfWork unitOfWork,IMapper mapper):IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public Task AddAppointmentAsync(AddAppointmentDto Entity)
    {
       // Entity.DoctorId = DefaultUser.DoctorId;
        var appointment = _mapper.Map<Appointment>(Entity);
        _unitOfWork.GetRepository<Appointment,int>().AddAsync(appointment);
        return _unitOfWork.CompleteAsync();
    }

    public Task<IEnumerable<AppointmentDto>> GetAllIncludingDeletedAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentAsync()
    {
        var appointments = await _unitOfWork.GetRepository<Appointment,int>().GetAllAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public Task<MedicineDTO> GetAppointmentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppointmentDto>> GetDeletedOnlyAsync()
    {
        throw new NotImplementedException();
    }

    public Task HardDeleteAppointmentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RestoreAppointmentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteAppointmentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateAppointmentAsync(UpdateMedicineDTO Entity)
    {
        throw new NotImplementedException();
    }
}
